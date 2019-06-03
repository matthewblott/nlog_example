using Microsoft.AspNetCore.Mvc;

namespace nlog_example.web
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}