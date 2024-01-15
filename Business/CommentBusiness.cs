using Business.Contracts;
using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business;
public class CommentBusiness : ICommentBusiness
{
    ICommentRepository _iCommentRepository;

    public CommentBusiness(ICommentRepository iCommentRepository)
    {
        _iCommentRepository = iCommentRepository;
    }

    public async Task<Comment> CreateAsync(Comment comment)
    {
        comment.DateCreated = DateTime.Now;
        comment.DateUpdated = DateTime.Now;
        return await _iCommentRepository.CreateAsync(comment);
    }

    public async Task DeleteAsync(int id)
        => await _iCommentRepository.DeleteAsync(id);

    public async Task<List<Comment>> GetAllAsync()
        => await _iCommentRepository.GetAllAsync();

    public async Task<Comment> GetByIdAsync(int id)
        => await _iCommentRepository.GetByIdAsync(id);

    public async Task<Comment> UpdateAsync(Comment comment)
    {
        comment.DateUpdated = DateTime.Now;
        return await _iCommentRepository.UpdateAsync(comment);
    }
}
