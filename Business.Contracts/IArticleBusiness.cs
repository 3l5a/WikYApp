using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts;
public interface IArticleBusiness
{
    public Task<Article> CreateAsync(Article article);
    public Task<Article> GetByIdAsync(int id);
    public Task<List<Article>> GetAllAsync();
    public Task<Article> UpdateAsync(Article article);
    public Task DeleteAsync(int id);
    public Task<bool> IsThemeUniqueAsync(string input);
    public Task<Article> GetLastAddedAsync();
}
