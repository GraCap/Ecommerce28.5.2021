using Ecommerce.Core.Entities;
using Ecommerce.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.AnagraficaClientiWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                #region Insert Clients
                //Client c1 = new Client
                //{
                //    ClientCode = "A123",
                //    FirstName = "Graziella",
                //    LastName = "Caputo",
                //};

                //Client c2 = new Client
                //{
                //    ClientCode = "B234",
                //    FirstName = "Ilaria",
                //    LastName = "Bonelli",
                //};
                //Client c3 = new Client
                //{
                //    ClientCode = "C345",
                //    FirstName = "Matilde",
                //    LastName = "Bonadia",
                //};


                //ctx.Clients.Add(c1);
                //ctx.Clients.Add(c2);
                //ctx.Clients.Add(c3);
                #endregion

                #region Select Clients

                //foreach (var item in ctx.Clients)
                //    Console.WriteLine($"[{item.ID}] Codice: {item.ClientCode} Cliente: {item.FirstName} {item.LastName}");

                #endregion

                #region Update Client

                //var client = ctx.Clients.FirstOrDefault(c => c.ClientCode == "A123");
                //client.FirstName = "Gra";  

                #endregion

                #region Delete Client

                //var client = ctx.Clients.FirstOrDefault(c => c.ID == 3);
                //ctx.Clients.Remove(client);

                #endregion

                #region Report Ordini per Anno

                Console.WriteLine("\nVisualizza report degli ordini nell'ultimo anno ");

                var lastYearOrders =
                   from order in ctx.Orders
                   where order.OrderDate.Year == DateTime.Today.Year
                   select new
                   {
                       ID = order.ID,
                       OrderDate = order.OrderDate,
                       OrderCode = order.OrderCode,
                       ProductCode = order.ProductCode,
                       Amount = order.Amount,
                       ClientId = order.ClientId,
                   };

                foreach (var item in lastYearOrders)
                    Console.WriteLine($"Ordine n° {item.ID}. Data: {item.OrderDate}. Codice Prodotto: {item.ProductCode}." +
                        $"Importo: {item.Amount}");

                #endregion

                #region Dettagli Ordine per uno specifico Ordine

                Console.WriteLine("\nVisualizza dettagli dell'ordine n° (inserisci id ordine): ");
                int.TryParse(Console.ReadLine(), out int idOrdine);

                var orderDetails =
                   from order in ctx.Orders
                   where order.ID == idOrdine
                   select new
                   {
                      ID = order.ID,
                      OrderDate = order.OrderDate,
                      OrderCode = order.OrderCode,
                      ProductCode = order.ProductCode,
                      Amount = order.Amount,
                      ClientId = order.ClientId,
                   };

                foreach (var item in orderDetails)
                    Console.WriteLine($"Ordine n° {item.ID}. Data: {item.OrderDate}. Codice Prodotto: {item.ProductCode}." +
                        $"Importo: {item.Amount}");

                #endregion

                #region Elenco Ordini per uno specifico Cliente
                Console.WriteLine("\nVisualizza ordini associati a (inserisci id cliente): ");
                int.TryParse(Console.ReadLine(), out int idCliente);

                var ordersPerClient =
                   from client in ctx.Clients
                   join order in ctx.Orders on client.ID equals order.ClientId
                   where client.ID == idCliente
                   select new
                   {
                       ID = order.ID,
                       OrderDate = order.OrderDate,
                       OrderCode = order.OrderCode,
                       ProductCode = order.ProductCode,
                       Amount = order.Amount,
                       ClientId = order.ClientId,
                   };

                foreach (var item in ordersPerClient)
                    Console.WriteLine($"Ordine n° {item.ID}. Data: {item.OrderDate}. Codice Prodotto: {item.ProductCode}." +
                        $"Importo: {item.Amount}");

                #endregion

                //ctx.SaveChanges();
                Console.ReadLine();
            }

        }
    }
}
