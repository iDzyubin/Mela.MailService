using Microsoft.AspNetCore.Mvc;

namespace Mela.MailService.Api.Controllers;

public class MailController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}