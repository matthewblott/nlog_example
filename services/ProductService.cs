using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace nlog_example.services
{
  public class ProductService : IProductService
  {
    private const string Filename = "products.json";
    private readonly IEnumerable<Product> _products = new List<Product>();

    public ProductService()
    {
      if (File.Exists(Filename))
      {
        var json = File.ReadAllText(Filename);
        _products = JsonConvert.DeserializeObject<IList<Product>>(json);
      }

    }

    public Product GetById(int id)
    {
      var q = from x in _products where x.Id == id select x;
      var product = q.FirstOrDefault();

      return product;

    }

    public IEnumerable<Product> GetProducts()
    {
      return _products;
    }
    
  }

}