// <copyright file="PaymentProcessService.cs" company="Anonymous Corp.">
// Copyright (c) Anonymous Corp.. All rights reserved.
// </copyright>

namespace ElasticSearch.Lib.Services
{
    using System;
    using System.Threading.Tasks;
    using Elastic.Clients.Elasticsearch;
    using Elastic.Clients.Elasticsearch.IndexManagement;
    using ElasticSearch.Lib.Interfaces;
    using ElasticSearch.Lib.Objects;

    /// <summary>
    /// Implement the payment process functionalities.
    /// </summary>
    public class PaymentProcessService : IPaymentProcess
    {
        /// <summary>
        /// Save the new transaction to elastic search.
        /// </summary>
        /// <param name="paymentProcess">Holds the payment process object.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return 1 is saved successfully. 0 means is not saved.</returns>
        public async Task<int> SavePaymentTransaction(PaymentProcess paymentProcess)
        {
            paymentProcess.PaymentId = Ulid.NewUlid().ToString();
            paymentProcess.Datetime = DateTime.UtcNow;
            paymentProcess.IsInvalidTransactions = true;
            int result = 0;
            ElasticClientService elasticClientService = new ElasticClientService();
            ElasticsearchClient client = await elasticClientService.GetElasticClient();
            IndexRequest<PaymentProcess> indexRequest = new IndexRequest<PaymentProcess>(paymentProcess, index: nameof(PaymentProcess).ToLower());
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
    }
}
