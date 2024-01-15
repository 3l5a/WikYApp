using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts;
public interface ICommentRepository
{
    public Task<Comment> CreateAsync(Comment comment);
    public Task<Comment> GetByIdAsync(int id);
    public Task<List<Comment>> GetAllAsync();
    public Task<Comment> UpdateAsync(Comment comment);
    public Task DeleteAsync(int id);
}
