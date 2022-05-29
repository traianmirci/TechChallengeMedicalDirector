using MedicalDirector.Domain.Entities;

namespace MedicalDirector.Services
{
    public interface IExternalService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<IEnumerable<Post>> GetPosts();
        Task<IEnumerable<Post>> GetUserPosts(int userId);
    }
}
