using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WikYApp.Controllers;
public class ArticleController : Controller
{
    IArticleBusiness _articleBusiness;

    public ArticleController(IArticleBusiness iArticleBusiness)
    {
        _articleBusiness = iArticleBusiness;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _articleBusiness.GetAllAsync());
    }

    public async Task<IActionResult> Show(int id)
    {
        Article article = await _articleBusiness.GetByIdAsync(id);
        return View(article);
    }

    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> New(Article article)
    {

        await _articleBusiness.CreateAsync(article);
        TempData["articleCreated"] = "Votre article est bien enregistré";
        return RedirectToAction("Show", new { id = article.Id});
    }

    public ActionResult Edit(int id)
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Article article)
    {
        await _articleBusiness.UpdateAsync(article);
        TempData["articleUpdated"] = "Article mis à jour avec succès";
        return RedirectToAction("Show", new { id = article.Id });
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _articleBusiness.DeleteAsync(id);
        TempData["articleDeleted"] = "Article supprimé avec succès";
        return RedirectToAction("Index");
    }

    public async Task<bool> IsThemeUnique(string input)
    {
        return await _articleBusiness.IsThemeUniqueAsync(input);
    }
}
