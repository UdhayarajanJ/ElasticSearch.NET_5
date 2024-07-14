// <copyright file="Program.cs" company="Anonymous Corp.">
// Copyright (c) Anonymous Corp.. All rights reserved.
// </copyright>

namespace ElasticSearch.Experiments
{
    using System;
    using ElasticSearch.Lib.Interfaces;
    using ElasticSearch.Lib.Objects;
    using ElasticSearch.Lib.Services;

    /// <summary>
    /// Entry point of the files.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        protected Program()
        {
        }

        /// <summary>
        /// Entry point of application main methods.
        /// </summary>
        /// <param name="args">Holds the pre requsit Arguments.</param>
        public static void Main(string[] args)
        {
            PaymentProcess paymentProcess = new PaymentProcess();
            paymentProcess.Name = "Udhayarajan J";
            paymentProcess.PaymentType = "UPI";
            paymentProcess.Amount = 12000.00m;
            paymentProcess.TransactionId = Guid.NewGuid().ToString();
            IPaymentProcess paymentProcessService = new PaymentProcessService();
            paymentProcessService.SavePaymentTransaction(paymentProcess).Wait();
            Console.WriteLine("Hello World!");
        }
    }
}
