using Kodluyoruz_Week1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kodluyoruz_Week1.Data
{
    public sealed class SingletonData
    {

        public List<ProductModel> products = new List<ProductModel>();
        private SingletonData()
        {
            var productJson = System.Text.Json.JsonSerializer.Serialize(products);
            Console.WriteLine(productJson);
            string path = @"C:\Users\duyguevrim\source\repos\week1-homework1-duyguevrim\Kodluyoruz-Week1\Kodluyoruz-Week1\product.json";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(productJson);
                }
            }
            else
            {
                // Open the file to read from.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {

                        var jsonResult = JsonConvert.DeserializeObject(s).ToString();
                        dynamic dynJson = JsonConvert.DeserializeObject(jsonResult);
                        foreach (var item in dynJson)
                        {
                            products.Add(new ProductModel
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Price = item.Price
                            });
                        }
                    }
                }
            }
        }
        public static SingletonData Instance { get { return Nested.instance; } }
        private class Nested
        {

            static Nested()
            {
            }
            internal static readonly SingletonData instance = new SingletonData();
        }
    }
}


