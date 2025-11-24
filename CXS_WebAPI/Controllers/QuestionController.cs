using Microsoft.AspNetCore.Mvc;

namespace CXS_WebAPI.Controllers;

public class QuestionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}