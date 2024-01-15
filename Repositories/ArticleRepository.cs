using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contexts;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class ArticleRepository : IArticleRepository
{
    WikYContext _context;

    public ArticleRepository(WikYContext context)
    {
        _context = context;
    }

    public async Task<Article> CreateAsync(Article article)
    {
        article.DateCreated = DateTime.Now;
        article.DateUpdated = DateTime.Now;
        await _context.Articles.AddAsync(article);
        await _context.SaveChangesAsync();

        return article;
    }

    public async Task<Article> GetByIdAsync(int id)
    {
        return await _context.Articles
            .Include(a => a.Comments)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<Article>> GetAllAsync()
    {
        return await _context.Articles.ToListAsync();
    }

    public async Task<Article> UpdateAsync(Article article)
    {
        Article articleInDb = await _context.Articles.FirstOrDefaultAsync(a => a.Id == article.Id);

        articleInDb.DateUpdated = DateTime.Now;
        articleInDb.Content = article.Content;
        _context.Articles.Update(articleInDb);

        await _context.SaveChangesAsync();

        return articleInDb;
    }
    public async Task DeleteAsync(int id)
    {
        Article article = await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsThemeUniqueAsync(string input)
    {
        return await _context.Articles.AnyAsync(a => a.Theme == input);
    }
}
