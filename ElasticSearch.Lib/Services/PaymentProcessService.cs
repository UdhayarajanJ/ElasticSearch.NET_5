// <copyright file="PaymentProcessService.cs" company="Anonymous Corp.">
// Copyright (c) Anonymous Corp.. All rights reserved.
// </copyright>

namespace ElasticSearch.Lib.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Elastic.Clients.Elasticsearch;
    using Elastic.Clients.Elasticsearch.QueryDsl;
    using ElasticSearch.Lib.Interfaces;
    using ElasticSearch.Lib.Objects;

    /// <summary>
    /// Implement the payment process functionalities.
    /// </summary>
    public class PaymentProcessService : IPaymentProcess
    {
        /// <summary>
        /// Delete the payment transactions.
        /// </summary>
        /// <param name="paymentId">request to delete payment id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return 1 is deleted successfully. 0 means is not deleted.</returns>
        public async Task<int> DeletePaymentTransactions(string paymentId)
        {
            int result = 0;
            ElasticClientService elasticClientService = new ElasticClientService();
            ElasticsearchClient client = await elasticClientService.GetElasticClient();
            DeleteResponse deleteResponse = await client.DeleteAsync<PaymentProcess>(index: nameof(PaymentProcess).ToLower(), id: paymentId);
            if (deleteResponse.IsValidResponse)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Get all payment transactions.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return list of transaction details.</returns>
        public async Task<List<PaymentProcess>> GetAllPaymentTransaction()
        {
            ElasticClientService elasticClientService = new ElasticClientService();
            ElasticsearchClient client = await elasticClientService.GetElasticClient();
            SearchResponse<PaymentProcess> searchResponse = await client.SearchAsync<PaymentProcess>(
                configureRequest: x =>
                {
                    x.Index(nameof(PaymentProcess).ToLower());
                    x.From(0);
                });
            if (searchResponse.IsValidResponse)
            {
                IReadOnlyCollection<PaymentProcess> paymentProcessesList = searchResponse.Documents;
                List<PaymentProcess> paymentProcessResponseList = new List<PaymentProcess>();
                foreach (var item in paymentProcessesList)
                {
                    paymentProcessResponseList.Add(item);
                }

                return paymentProcessResponseList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get the payment transactions with specified limits.
        /// </summary>
        /// <param name="limit">request the limit size.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return list of transaction details.</returns>
        public async Task<List<PaymentProcess>> GetPaymentTransactionWithLimit(int limit)
        {
            ElasticClientService elasticClientService = new ElasticClientService();
            ElasticsearchClient client = await elasticClientService.GetElasticClient();
            SearchResponse<PaymentProcess> searchResponse = await client.SearchAsync<PaymentProcess>(
                configureRequest: x =>
                {
                    x.Index(nameof(PaymentProcess).ToLower());
                    x.From(0);
                    x.Size(limit);
                });
            if (searchResponse.IsValidResponse)
            {
                IReadOnlyCollection<PaymentProcess> paymentProcessesList = searchResponse.Documents;
                List<PaymentProcess> paymentProcessResponseList = new List<PaymentProcess>();
                foreach (var item in paymentProcessesList)
                {
                    paymentProcessResponseList.Add(item);
                }

                return paymentProcessResponseList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get the payment transaction with range of amount.
        /// </summary>
        /// <param name="fromAmount">request from amount.</param>
        /// <param name="toAmount">request to amount.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return list of transaction details.</returns>
        public async Task<List<PaymentProcess>> GetPaymentTransaction_By_Amount_Range(decimal fromAmount, decimal toAmount)
        {
            ElasticClientService elasticClientService = new ElasticClientService();
            ElasticsearchClient client = await elasticClientService.GetElasticClient();
            SearchResponse<PaymentProcess> searchResponse = await client.SearchAsync<PaymentProcess>(configureRequest: x =>
            {
                x.Index(nameof(PaymentProcess).ToLower());
                x.From(0);
                x.Query(x => x.Match(x => x.Field(x => x.IsInvalidTransactions).Query(false)));
                x.Query(x => x.Range(x => x.NumberRange(from => from.Field(x => x.Amount).Gte(Convert.ToDouble(fromAmount)).Lte(Convert.ToDouble(toAmount)))));
            });
            if (searchResponse.IsValidResponse)
            {
                IReadOnlyCollection<PaymentProcess> paymentProcessesList = searchResponse.Documents;
                List<PaymentProcess> paymentProcessResponseList = new List<PaymentProcess>();
                foreach (var item in paymentProcessesList)
                {
                    paymentProcessResponseList.Add(item);
                }

                return paymentProcessResponseList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get the payment transaction by id.
        /// </summary>
        /// <param name="paymentId">request to delete payment id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return payment transaction details.</returns>
        public async Task<PaymentProcess> GetPaymentTransaction_By_Id(string paymentId)
        {
            ElasticClientService elasticClientService = new ElasticClientService();
            ElasticsearchClient client = await elasticClientService.GetElasticClient();
            GetResponse<PaymentProcess> getResponse = await client.GetAsync<PaymentProcess>(index: nameof(PaymentProcess).ToLower(), id: paymentId);
            if (getResponse.IsValidResponse)
            {
                PaymentProcess paymentProcess = getResponse.Source;
                return paymentProcess;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get the payment transactions with specified name.
        /// </summary>
        /// <param name="name">request the payment user name.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return list of transaction details.</returns>
        public async Task<List<PaymentProcess>> GetPaymentTransaction_By_Name(string name)
        {
            ElasticClientService elasticClientService = new ElasticClientService();
            ElasticsearchClient client = await elasticClientService.GetElasticClient();
            SearchResponse<PaymentProcess> searchResponse = await client.SearchAsync<PaymentProcess>(
                configureRequest: x =>
                {
                    x.Index(nameof(PaymentProcess).ToLower());
                    x.From(0);
                    x.Query(x => x.Wildcard(x => x.Field(x => x.Name.Suffix("keyword")).Value($"*{name}*")));
                });
            if (searchResponse.IsValidResponse)
            {
                IReadOnlyCollection<PaymentProcess> paymentProcessesList = searchResponse.Documents;
                List<PaymentProcess> paymentProcessResponseList = new List<PaymentProcess>();
                foreach (var item in paymentProcessesList)
                {
                    paymentProcessResponseList.Add(item);
                }

                return paymentProcessResponseList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Make the invalid payment transactions.
        /// </summary>
        /// <param name="paymentId">request to delete payment id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return 1 is success result.</returns>
        public async Task<int> Make_Invalid_PaymentTransactions(string paymentId)
        {
            int result = 0;
            ElasticClientService elasticClientService = new ElasticClientService();
            ElasticsearchClient client = await elasticClientService.GetElasticClient();
            PaymentProcess paymentProcess = await this.GetPaymentTransaction_By_Id(paymentId);
            paymentProcess.IsInvalidTransactions = true;
            UpdateResponse<PaymentProcess> response = await client.UpdateAsync<PaymentProcess, PaymentProcess>(index: nameof(PaymentProcess).ToLower(), id: paymentId, configureRequest: x => x.Doc(paymentProcess));
            if (response.IsValidResponse)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Save the new transaction to elastic search.
        /// </summary>
        /// <param name="paymentProcess">Holds the payment process object.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return 1 is saved successfully. 0 means is not saved.</returns>
        public async Task<int> SavePaymentTransaction(PaymentProcess paymentProcess)
        {
            paymentProcess.PaymentId = Ulid.NewUlid().ToString();
            paymentProcess.Datetime = DateTime.UtcNow;
            paymentProcess.IsInvalidTransactions = false;
            int result = 0;
            ElasticClientService elasticClientService = new ElasticClientService();
            ElasticsearchClient client = await elasticClientService.GetElasticClient();
            IndexRequest<PaymentProcess> indexRequest = new IndexRequest<PaymentProcess>(paymentProcess, index: nameof(PaymentProcess).ToLower(), paymentProcess.PaymentId);
            IndexResponse response = await client.IndexAsync<PaymentProcess>(indexRequest);
            if (response.IsValidResponse)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Update the existing transaction to elastic search.
        /// </summary>
        /// <param name="paymentProcess">Holds the payment process object.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return 1 is updated successfully. 0 means is not updated.</returns>
        public async Task<int> UpdatePaymentTransaction(PaymentProcess paymentProcess)
        {
            int result = 0;
            paymentProcess.Datetime = DateTime.UtcNow;
            ElasticClientService elasticClientService = new ElasticClientService();
            ElasticsearchClient client = await elasticClientService.GetElasticClient();
            UpdateResponse<PaymentProcess> response = await client.UpdateAsync<PaymentProcess, PaymentProcess>(index: nameof(PaymentProcess).ToLower(), id: paymentProcess.PaymentId, configureRequest: x => x.Doc(paymentProcess));
            if (response.IsValidResponse)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
}
