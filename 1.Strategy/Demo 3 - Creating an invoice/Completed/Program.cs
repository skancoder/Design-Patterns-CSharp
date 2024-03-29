﻿using Strategy_Pattern_Creating_an_invoice.Business.Models;
using Strategy_Pattern_Creating_an_invoice.Business.Strategies.Invoice;
using Strategy_Pattern_Creating_an_invoice.Business.Strategies.SalesTax;
using System;

namespace Strategy_Pattern_Creating_an_invoice
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails 
                { 
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                },
                SalesTaxStrategy = new SwedenSalesTaxStrategy(),//easily replace this contrete implementation to USA
                InvoiceStrategy = new PrintOnDemandInvoiceStrategy()//easily replace this contrete implementation to fileInvoice,emailInvoice
            };

            //decoupling order using STRATEGY pattern

            order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);

            Console.WriteLine(order.GetTax());

            order.FinalizeOrder();
        }
    }
}
