using Refit;
using slot_4.Models;

namespace CallApi;

public interface ICategoryData
{
    [Get("/Category")]
    Task<List<Category>> GetCategories();

    [Get("/Category/{id}")]
    Task<string> GetCategory(int id);
    [Post("/Category")]
    Task<string> CreateCategory([Body] Category cat);
    [Put("/Category")]
    Task<string> UpdateCategory([Body] Category cat);
    [Delete("/Category/{id}")]
    Task<string> DeleteCategory(int id);
}