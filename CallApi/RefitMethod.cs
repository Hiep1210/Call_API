using Newtonsoft.Json;
using Refit;
using slot_4.Models;

namespace CallApi;

public class RefitMethod
{
    private static readonly string link = "http://localhost:5000/api";
    private ICategoryData CateData;
    private JsonSerializer serializer;
    public RefitMethod()
    {
        CateData = RestService.For<ICategoryData>(link);
        serializer = new Newtonsoft.Json.JsonSerializer();
    }
    public async Task getAllCategories()
    {

        List<Category> Categories =  await CateData.GetCategories();
        Display(Categories.ToArray());
    }

    public async Task GetCategory(int id)
    {
        string strCate = await CateData.GetCategory(id);
        Category cate = serializer.Deserialize<Category>(new JsonTextReader(new StringReader(strCate)));
        Display(cate);
    }

    public async Task CreateCategory(Category cate)
    {
        var mess = await CateData.CreateCategory(cate);
        try
        {
            Category category = serializer.Deserialize<Category>(new JsonTextReader(new StringReader(mess)));

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine(mess);

    }

    public async Task UpdateCategory(int id, string cateName)
    {
        var cate = new Category()
        {
            CategoryId = id,
            CategoryName = cateName
        };
        var mess = await CateData.UpdateCategory(cate);
        Console.WriteLine(mess);

    }

    public async Task DeleteCategory(int id)
    {
        var cate = await CateData.DeleteCategory(id);
        Console.WriteLine(cate);
    }

    private void Display(params Category[] categories)
    {
        foreach (var category in categories)
        {
            Console.WriteLine(category);
        }
    }
}