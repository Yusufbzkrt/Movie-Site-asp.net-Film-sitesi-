using LinqSamples.Data;
using System;
using System.Linq;

namespace LinqSamples
{

    class ProductModel
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                /*----- tüm müşteri kayıtarını getirir ( Customers ) ------*/
                //var Customers = db.Customers.ToList();
                //foreach (var employe in Customers)
                //{
                //    Console.WriteLine(employe.ContactName);
                //}

                /*--- tüm müşterilerin sadece customerId ve Contact name ini getir*/
                //var customers= db.Customers.Select(c=> new {c.CustomerId,c.ContactName}).ToList();
                //    foreach (var customer in customers)
                //    {
                //        Console.WriteLine(customer.ContactName + " "+customer.ContactName);
                //    }

                /*ürünler tablosundaki ilk 5 kaydı alınız*/
                //var products = db.Products.Take(5).ToList();
                //foreach (var product in products) {
                //    Console.WriteLine(product.ProductName+" "+product.ProductId);
                //}

                /*ürünler tablosundaki ikinci 5 kaydı alınız*/
                //var products = db.Products.Skip(5).Take(5).ToList();
                //foreach (var product in products)
                //{
                //    Console.WriteLine(product.ProductName + " " + product.ProductId);
                //}
            }
           
        }
    }
}
