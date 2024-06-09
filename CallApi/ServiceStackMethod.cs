using Newtonsoft.Json;
using ServiceStack;
using slot_4.Models;

namespace CallApi;

public class ServiceStackMethod
{
    private static readonly string link = "http://localhost:5000/api/Category";
    JsonServiceClient client;
    public ServiceStackMethod()
    { 
        client = new JsonServiceClient(link);
    }
    public async Task getAllCategories()
    {
        string response = await client.GetAsync<string>("");
        Console.WriteLine(response);

    }

    public async Task GetCategory(int id)
    {
        string response = await client.GetAsync<string>("/"+id);
        Console.WriteLine(response);
    }

    public async Task CreateCategory(Category cate)
    {
        string response = await client.PostAsync<string>("", cate);
        Console.WriteLine(response);
    }

    public async Task UpdateCategory(int id, string cateName)
    {
        var cate = new Category()
        {
            CategoryId = id,
            CategoryName = cateName
        };
        string response = await client.PutAsync<string>("", cate);
        Console.WriteLine(response);
    }

    public async Task DeleteCategory(int id)
    {
        string response = await client.DeleteAsync<string>("/"+id);
        Console.WriteLine(response);
    }

}