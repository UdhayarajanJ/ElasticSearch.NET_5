// <copyright file="Program.cs" company="Anonymous Corp.">
// Copyright (c) Anonymous Corp.. All rights reserved.
// </copyright>

namespace ElasticSearch.Experiments
{
    using System;
    using System.Collections.Generic;
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
            bool validRunAgain = false;
            int runAgain = 0;
            do
            {
                Console.WriteLine("Operations.");
                Console.Write("\n 1.Save New Transactions.");
                Console.Write("\n 2.Update Existing Transactions.");
                Console.Write("\n 3.Get All Transactions.");
                Console.Write("\n 4.Get Top Limit Transactions.");
                Console.Write("\n 5.Get Transactions By Name.");
                Console.Write("\n 6.Get Transactions Based On The Amount Range.");
                Console.Write("\n 7.Delete Transactions.");
                Console.Write("\n 8.Get Transactions By Payment Id.");
                Console.Write("\n 9.Make Invalid Transactions.");
                Console.Write("\n\n Enter the options. : ");
                int choice = 0;
                bool validChoice = int.TryParse(Console.ReadLine(), out choice);
                if (!validChoice)
                {
                    Console.WriteLine("\n Invaild option...");
                }
                else
                {
                    PaymentProcess paymentProcess = null;
                    IPaymentProcess paymentProcessService = null;
                    string paymentId = string.Empty;
                    List<PaymentProcess> resultList = null;
                    int result = 0;
                    switch (choice)
                    {
                        case 1:
                            paymentProcess = GetUserInput();
                            paymentProcessService = new PaymentProcessService();
                            result = paymentProcessService.SavePaymentTransaction(paymentProcess).Result;
                            if (result == 1)
                            {
                                Console.WriteLine("\n\n Transaction was saved.");
                            }
                            else
                            {
                                Console.WriteLine("\n\n Transaction was not saved.");
                            }

                            break;
                        case 2:
                            Console.Write("\n\n Enter the payment id. : ");
                            paymentId = Console.ReadLine();
                            paymentProcess = GetUserInput();
                            paymentProcess.PaymentId = paymentId;
                            paymentProcessService = new PaymentProcessService();
                            result = paymentProcessService.UpdatePaymentTransaction(paymentProcess).Result;
                            if (result == 1)
                            {
                                Console.WriteLine("\n\n Transaction was update.");
                            }
                            else
                            {
                                Console.WriteLine("\n\n Transaction was not update.");
                            }

                            break;
                        case 3:
                            paymentProcessService = new PaymentProcessService();
                            resultList = paymentProcessService.GetAllPaymentTransaction().Result;
                            if (resultList != null)
                            {
                                foreach (PaymentProcess item in resultList)
                                {
                                    Console.WriteLine("\n");
                                    Console.WriteLine($"PaymentId      : {item.PaymentId}");
                                    Console.WriteLine($"Name           : {item.Name}");
                                    Console.WriteLine($"Amount         : {item.Amount}");
                                    Console.WriteLine($"Transaction Id : {item.TransactionId}");
                                    Console.WriteLine($"Payment Type   : {item.PaymentType}");
                                    Console.WriteLine("\n");
                                }
                            }

                            break;
                        case 4:
                            Console.Write("\n\n Enter the request size. : ");
                            int size = Convert.ToInt32(Console.ReadLine());
                            paymentProcessService = new PaymentProcessService();
                            resultList = paymentProcessService.GetPaymentTransactionWithLimit(size).Result;
                            if (resultList != null)
                            {
                                foreach (PaymentProcess item in resultList)
                                {
                                    Console.WriteLine("\n");
                                    Console.WriteLine($"PaymentId      : {item.PaymentId}");
                                    Console.WriteLine($"Name           : {item.Name}");
                                    Console.WriteLine($"Amount         : {item.Amount}");
                                    Console.WriteLine($"Transaction Id : {item.TransactionId}");
                                    Console.WriteLine($"Payment Type   : {item.PaymentType}");
                                    Console.WriteLine("\n");
                                }
                            }

                            break;
                        case 5:
                            Console.Write("\n\n Enter the request name. : ");
                            string name = Console.ReadLine();
                            paymentProcessService = new PaymentProcessService();
                            resultList = paymentProcessService.GetPaymentTransaction_By_Name(name).Result;
                            if (resultList != null)
                            {
                                foreach (PaymentProcess item in resultList)
                                {
                                    Console.WriteLine("\n");
                                    Console.WriteLine($"PaymentId      : {item.PaymentId}");
                                    Console.WriteLine($"Name           : {item.Name}");
                                    Console.WriteLine($"Amount         : {item.Amount}");
                                    Console.WriteLine($"Transaction Id : {item.TransactionId}");
                                    Console.WriteLine($"Payment Type   : {item.PaymentType}");
                                    Console.WriteLine("\n");
                                }
                            }

                            break;
                        case 6:
                            Console.Write("\n\n Enter the request from amount. : ");
                            decimal fromAmount = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("\n Enter the request to amount. : ");
                            decimal toAmount = Convert.ToDecimal(Console.ReadLine());
                            paymentProcessService = new PaymentProcessService();
                            resultList = paymentProcessService.GetPaymentTransaction_By_Amount_Range(fromAmount, toAmount).Result;
                            if (resultList != null)
                            {
                                foreach (PaymentProcess item in resultList)
                                {
                                    Console.WriteLine("\n");
                                    Console.WriteLine($"PaymentId      : {item.PaymentId}");
                                    Console.WriteLine($"Name           : {item.Name}");
                                    Console.WriteLine($"Amount         : {item.Amount}");
                                    Console.WriteLine($"Transaction Id : {item.TransactionId}");
                                    Console.WriteLine($"Payment Type   : {item.PaymentType}");
                                    Console.WriteLine("\n");
                                }
                            }

                            break;
                        case 7:
                            Console.Write("\n\n Enter the payment id. : ");
                            paymentId = Console.ReadLine();
                            paymentProcessService = new PaymentProcessService();
                            result = paymentProcessService.DeletePaymentTransactions(paymentId).Result;
                            if (result == 1)
                            {
                                Console.WriteLine("\n\n Transaction was deleted.");
                            }
                            else
                            {
                                Console.WriteLine("\n\n Transaction was not deleted.");
                            }

                            break;
                        case 8:
                            Console.Write("\n\n Enter the payment id. : ");
                            paymentId = Console.ReadLine();
                            paymentProcessService = new PaymentProcessService();
                            PaymentProcess getResult = paymentProcessService.GetPaymentTransaction_By_Id(paymentId).Result;
                            if (getResult != null)
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine($"PaymentId      : {getResult.PaymentId}");
                                Console.WriteLine($"Name           : {getResult.Name}");
                                Console.WriteLine($"Amount         : {getResult.Amount}");
                                Console.WriteLine($"Transaction Id : {getResult.TransactionId}");
                                Console.WriteLine($"Payment Type   : {getResult.PaymentType}");
                                Console.WriteLine("\n");
                            }

                            break;
                        case 9:
                            Console.Write("\n\n Enter the payment id. : ");
                            paymentId = Console.ReadLine();
                            paymentProcessService = new PaymentProcessService();
                            result = paymentProcessService.Make_Invalid_PaymentTransactions(paymentId).Result;
                            if (result == 1)
                            {
                                Console.WriteLine("\n\n Transaction was invalid.");
                            }
                            else
                            {
                                Console.WriteLine("\n\n Transaction was not invalid.");
                            }

                            break;
                    }
                }

                Console.Write("\n\n To you want continue press 1: ");
                validRunAgain = int.TryParse(Console.ReadLine(), out runAgain);
                if (!validRunAgain)
                {
                    Console.WriteLine("\n Terminate the process.");
                }
            }
            while (validRunAgain && runAgain == 1);
        }

        private static PaymentProcess GetUserInput()
        {
            PaymentProcess paymentProcess = new PaymentProcess();
            Console.Write("\n\n Enter the name. : ");
            paymentProcess.Name = Console.ReadLine();
            Console.Write("\n Enter the amount. : ");
            paymentProcess.Amount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("\n Enter the transaction id. : ");
            paymentProcess.TransactionId = Console.ReadLine();
            Console.Write("\n Enter the transaction type. : ");
            paymentProcess.PaymentType = Console.ReadLine();
            return paymentProcess;
        }
    }
}
