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
public class CommentRepository : ICommentRepository
{
    WikYContext _context;

    public CommentRepository(WikYContext context)
    {
        _context = context;
    }

    public async Task<Comment> CreateAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment> GetByIdAsync(int id)
    {
        Comment comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        return comment;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment> UpdateAsync(Comment comment)
    {
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task DeleteAsync(int id)
    {
        Comment comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }
}
