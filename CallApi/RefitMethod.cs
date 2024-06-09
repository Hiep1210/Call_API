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
        CateData = RestService.For<ICategoryData>(link, new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings())
        });
        serializer = new Newtonsoft.Json.JsonSerializer();
    }
    public async Task getAllCategories()
    {

        List<Category> Categories =  await CateData.GetCategories();
        //List<Category> cates = serializer.Deserialize<List<Category>>(new JsonTextReader(new StringReader(strCate)));
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
        Category c = JsonConvert.DeserializeObject<Category>(cate);
        Console.WriteLine(c);
    }

    private void Display(params Category[] categories)
    {
        foreach (var category in categories)
        {
            Console.WriteLine(category);
        }
    }
}