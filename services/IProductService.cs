using System.Collections.Generic;

namespace nlog_example.services
{
  public interface IProductService
  {
    IEnumerable<Product> GetProducts();
    Product GetById(int id);

  }
}