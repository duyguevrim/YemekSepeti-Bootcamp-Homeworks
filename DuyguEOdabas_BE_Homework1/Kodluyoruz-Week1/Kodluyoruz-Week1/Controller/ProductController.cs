using Kodluyoruz_Week1.Data;
using Kodluyoruz_Week1.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kodluyoruz_Week1.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly SingletonData _data;

        public ProductsController()
        {
            _data = SingletonData.Instance;

        }

        [HttpGet]
        public List<ProductModel> Get()
        {
            return _data.products;
        }

        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            var data = _data.products.FirstOrDefault(c => c.Id == id);
            return data;
        }

        [HttpPost]
        public void Post([FromBody] ProductModel product)
        {
            _data.products.Add(product);
            saveJsonToFile();
        }
        [HttpPut("{id}")]
        public ProductModel Put([FromBody] ProductModel product, int id)
        {
            var data = _data.products.FirstOrDefault(c => c.Id == id);
            data.Id = product.Id != null ? product.Id : data.Id;
            data.Name = product.Name != null ? product.Name : data.Name;
            data.Price = product.Price != null ? product.Price : data.Price;
            saveJsonToFile();
            return data;
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var data = _data.products.FirstOrDefault(c => c.Id == id);
            _data.products.Remove(data);
            saveJsonToFile();
            return "Deleted";
        }
        public void saveJsonToFile()
        {
            FileInfo fi = new FileInfo(@"C:\Users\duyguevrim\source\repos\week1-homework1-duyguevrim\Kodluyoruz-Week1\Kodluyoruz-Week1\product.json");
            var productJson = System.Text.Json.JsonSerializer.Serialize(_data.products);
            using (StreamWriter outputFile = new StreamWriter(fi.Open(FileMode.Truncate)))
            {
                outputFile.WriteLine(productJson);
            }
        }
    }
}


