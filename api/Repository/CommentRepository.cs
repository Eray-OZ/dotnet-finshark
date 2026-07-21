using System.Runtime.CompilerServices;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class CommentRepository : ICommentRepository
{

    private readonly ApplicationDbContext _context;
    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Comment> CreateAsync(Comment commentModel)
    {
        await _context.Comments.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetOneAsync(string id)
    {
        return await _context.Comments.FindAsync(Guid.Parse(id));
    }

    public async Task<Comment?> UpdateAsync(string id, Comment comment)
    {
        var guid = Guid.Parse(id);
        var commentModel = await _context.Comments.FindAsync(guid);
        if (commentModel==null) { return null; }

        commentModel.Title = comment.Title;
        commentModel.Content = comment.Content;

        await _context.SaveChangesAsync();

        return commentModel;
    }
}
