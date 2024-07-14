// <copyright file="IPaymentProcess.cs" company="Anonymous Corp.">
// Copyright (c) Anonymous Corp.. All rights reserved.
// </copyright>

namespace ElasticSearch.Lib.Interfaces
{
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
    }
}
