using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts;
public interface ICommentBusiness
{
    public Task<Comment> CreateAsync(Comment comment);
    public Task<Comment> GetByIdAsync(int id);
    public Task<List<Comment>> GetAllAsync();
    public Task<Comment> UpdateAsync(Comment comment);
    public Task DeleteAsync(int id);
}
