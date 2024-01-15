using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WikYApp.Controllers;
public class CommentController : Controller
{
    ICommentBusiness _commentBusiness;

    public CommentController(ICommentBusiness commentBusiness)
    {
        _commentBusiness = commentBusiness;
    }

    [HttpGet]
    public IActionResult New(int articleId)
    {
        ViewBag.ArticleId = articleId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> New(Comment comment)
    {
        await _commentBusiness.CreateAsync(comment);
        return RedirectToAction("Show", "Article", new { id = comment.ArticleId });
    }

    public async Task<IActionResult> Delete(Comment comment, int articleId)
    {
        await _commentBusiness.DeleteAsync(comment.Id);
        return RedirectToAction("Show", "Article", new { id = articleId });  
    }



    //not implemented
    public IActionResult Edit(int articleId)
    {
        ViewBag.ArticleId = articleId; //reuse in hidden input
        return View();
    }

    //not implemented
    public async Task<IActionResult> Edit(Comment comment, int articleId)
    {
        await _commentBusiness.UpdateAsync(comment);
        return RedirectToAction("Show", "Article", new { id = articleId });
    }
}
