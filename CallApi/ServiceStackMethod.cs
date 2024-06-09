using Newtonsoft.Json;
using ServiceStack;
using ServiceStack.Text;
using slot_4.Models;
using System;

namespace CallApi;

public class ServiceStackMethod
{
    private static readonly string link = "http://localhost:5000/api/Category";
    JsonServiceClient client;
    public ServiceStackMethod()
    {
        JsConfig<Category>.RawSerializeFn = cate => JsonConvert.SerializeObject(cate);
        JsConfig<Category>.RawDeserializeFn = json => JsonConvert.DeserializeObject<Category>(json);
        client = new JsonServiceClient(link);

    }
    public async Task getAllCategories()
    {
        List<Category> response = await client.GetAsync<List<Category>>("");
        Display(response.ToArray());

    }

    public async Task GetCategory(int id)
    {
        List<Category> response = await client.GetAsync<List<Category>>("/" + id);
        Display(response.ToArray());
    }

    public async Task CreateCategory(Category cate)
    {
        Category response = await client.PostAsync<Category>("", cate);
        Display(response);
    }

    public async Task UpdateCategory(int id, string cateName)
    {
        var cate = new Category()
        {
            CategoryId = id,
            CategoryName = cateName
        };
        Category response = await client.PutAsync<Category>("", cate);
        Display(response);
    }

    public async Task DeleteCategory(int id)
    {
        Category response = await client.DeleteAsync<Category>("/" + id);
        Display(response);
    }

    private void Display(params Category[] categories)
    {
        foreach (var category in categories)
        {
            Console.WriteLine(category);
        }
    }

}