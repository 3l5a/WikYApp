using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WikYApp.Models;

namespace WikYApp.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    IArticleBusiness _articleBusiness;

    public HomeController(ILogger<HomeController> logger, IArticleBusiness articleBusiness)
    {
        _logger = logger;
        _articleBusiness = articleBusiness;
    }

    public async Task<IActionResult> Index()
    {
        Article article = await _articleBusiness.GetLastAddedAsync();
        return View(article);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
