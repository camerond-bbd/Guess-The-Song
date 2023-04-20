using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using MVC_Exmaple.Models;

namespace MVC_Exmaple.Controllers;

public class HelloWorldController : Controller
{
    public HelloWorldController()
    {
    }

    public IActionResult Index(int? Id)
    {
        if (Id == null)
            return NotFound();

        DataSource.DataSource.HydrateUserModel(out UserModel? model,(int)Id);
        return View("AboutMe", model);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
