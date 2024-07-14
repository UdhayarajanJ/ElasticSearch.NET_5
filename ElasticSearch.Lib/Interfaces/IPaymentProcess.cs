// <copyright file="IPaymentProcess.cs" company="Anonymous Corp.">
// Copyright (c) Anonymous Corp.. All rights reserved.
// </copyright>

namespace ElasticSearch.Lib.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ElasticSearch.Lib.Objects;

    /// <summary>
    /// Declare payment process functionalities.
    /// </summary>
    public interface IPaymentProcess
    {
        /// <summary>
        /// Save the new transaction to elastic search.
        /// </summary>
        /// <param name="paymentProcess">Holds the payment process object.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return 1 is saved successfully. 0 means is not saved.</returns>
        public Task<int> SavePaymentTransaction(PaymentProcess paymentProcess);

        /// <summary>
        /// Update the existing transaction to elastic search.
        /// </summary>
        /// <param name="paymentProcess">Holds the payment process object.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return 1 is updated successfully. 0 means is not updated.</returns>
        public Task<int> UpdatePaymentTransaction(PaymentProcess paymentProcess);

        /// <summary>
        /// Get all payment transactions.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return list of transaction details.</returns>
        public Task<List<PaymentProcess>> GetAllPaymentTransaction();

        /// <summary>
        /// Get the payment transactions with specified limits.
        /// </summary>
        /// <param name="limit">request the limit size.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return list of transaction details.</returns>
        public Task<List<PaymentProcess>> GetPaymentTransactionWithLimit(int limit);

        /// <summary>
        /// Get the payment transactions with specified name.
        /// </summary>
        /// <param name="name">request the payment user name.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return list of transaction details.</returns>
        public Task<List<PaymentProcess>> GetPaymentTransaction_By_Name(string name);

        /// <summary>
        /// Get the payment transaction with range of amount.
        /// </summary>
        /// <param name="fromAmount">request from amount.</param>
        /// <param name="toAmount">request to amount.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return list of transaction details.</returns>
        public Task<List<PaymentProcess>> GetPaymentTransaction_By_Amount_Range(decimal fromAmount, decimal toAmount);

        /// <summary>
        /// Delete the payment transactions.
        /// </summary>
        /// <param name="paymentId">request to delete payment id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return 1 is deleted successfully. 0 means is not deleted.</returns>
        public Task<int> DeletePaymentTransactions(string paymentId);

        /// <summary>
        /// Get the payment transaction by id.
        /// </summary>
        /// <param name="paymentId">request to delete payment id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return payment transaction details.</returns>
        public Task<PaymentProcess> GetPaymentTransaction_By_Id(string paymentId);

        /// <summary>
        /// Make the invalid payment transactions.
        /// </summary>
        /// <param name="paymentId">request to delete payment id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return 1 is success result.</returns>
        public Task<int> Make_Invalid_PaymentTransactions(string paymentId);
    }
}
