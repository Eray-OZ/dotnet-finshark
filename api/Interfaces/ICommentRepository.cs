using api.Models;

namespace api.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
    Task<Comment> CreateAsync(Comment commentModel);
    Task<Comment?> GetOneAsync(string id);
    Task<Comment?> UpdateAsync(string id, Comment commentModel);

}
