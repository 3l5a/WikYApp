using Business.Contracts;
using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business;
public class ArticleBusiness : IArticleBusiness
{
    IArticleRepository _articleRepository;

    public ArticleBusiness(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<Article> CreateAsync(Article article)
    {
        article.DateCreated = DateTime.Now;
        article.DateUpdated = DateTime.Now;
        return await _articleRepository.CreateAsync(article);
    }

    public async Task DeleteAsync(int id)
        => await _articleRepository.DeleteAsync(id);

    public async Task<List<Article>> GetAllAsync()
        => await _articleRepository.GetAllAsync();

    public async Task<Article> GetByIdAsync(int id)
        => await _articleRepository.GetByIdAsync(id);

    public async Task<bool> IsThemeUniqueAsync(string input)
        => await _articleRepository.IsThemeUniqueAsync(input);

    public async Task<Article> UpdateAsync(Article article)
    {
        article.DateUpdated = DateTime.Now;
        return await _articleRepository.UpdateAsync(article);
    }

    public async Task<Article> GetLastAddedAsync()
    {
        var articles = await _articleRepository.GetAllAsync();
        return articles.LastOrDefault();
    }
}
