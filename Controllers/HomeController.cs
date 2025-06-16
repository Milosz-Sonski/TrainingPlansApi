using Microsoft.AspNetCore.Mvc;


public class HomeController : Controller
{
    // G³ówna strona
    public IActionResult Index()
    {
        return View();
    }
}
