using System.Collections.Generic;
using nlog_example.services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace nlog_example.web
{
  [ServiceFilter(typeof(LogFilter))]
  public class ProductsController : Controller
  {
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductsController> _logger;
    public ProductsController(IProductService productService, IMapper mapper, ILogger<ProductsController> logger)
    {
      _productService = productService;
      _mapper = mapper;
      _logger = logger;
      _logger.LogInformation(message: "ProductsController constructor called");
    }

    public IActionResult Index()
    {
      _logger.LogInformation(message: "ProductsController Index called");
      
      var products = _productService.GetProducts();
      var productViewModels = _mapper.Map<IEnumerable<ProductViewModel>>(products);
      
      return View(productViewModels);
    }

    public IActionResult Edit(int id)
    {
      var product = _productService.GetById(id);
      var productViewModel = _mapper.Map<ProductViewModel>(product);
      
      return View(productViewModel);
      
    }

  }
  
}