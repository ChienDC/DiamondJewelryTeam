using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelry.Areas.Admin.Controllers;

public class HomeController: AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}