using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace nlog_example.web
{
  public class ProductViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Sku { get; set; }
  }
}