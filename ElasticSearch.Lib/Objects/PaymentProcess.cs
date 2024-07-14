// <copyright file="PaymentProcess.cs" company="Anonymous Corp.">
// Copyright (c) Anonymous Corp.. All rights reserved.
// </copyright>

namespace ElasticSearch.Lib.Objects
{
    using System;

    /// <summary>
    /// Payment process model class.
    /// </summary>
    public class PaymentProcess
    {
        /// <summary>
        /// Gets or sets payment id.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Gets or sets transaction id.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets transaction date and time.
        /// </summary>
        public DateTime Datetime { get; set; }

        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets payment type.
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether invalid transactions.
        /// </summary>
        public bool IsInvalidTransactions { get; set; }
    }
}
