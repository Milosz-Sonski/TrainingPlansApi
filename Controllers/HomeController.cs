using Microsoft.AspNetCore.Mvc;


public class HomeController : Controller
{
    // G��wna strona
    public IActionResult Index()
    {
        return View();
    }
}
