using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using slot_4.Models;

namespace CallApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Manager m = new Manager();
            RestSharpMethod rest = new RestSharpMethod();
            FlurlMethod flurl = new FlurlMethod();
            RefitMethod refit = new RefitMethod();
            ServiceStackMethod servicestack = new ServiceStackMethod();


            var host = Host.CreateDefaultBuilder()
                 .ConfigureServices((context, services) =>
                 {
                     // Đăng ký HttpClientFactory
                     services.AddHttpClient();
                     // Đăng ký MyApiService
                     services.AddTransient<ClientFactory>();
                 })
                 .Build();

            // Lấy MyApiService từ DI container
            var myApiService = host.Services.GetRequiredService<ClientFactory>();

            int id;
            string name;
<<<<<<< HEAD
=======
            WebClientMethod webClient = new WebClientMethod();
>>>>>>> main
            while (true)
            {
                Console.WriteLine("1. Show List Category");
                Console.WriteLine("2. Search");
                Console.WriteLine("3. Insert");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose your way: ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //await m.ShowList();
                        //await rest.ShowList();
                        //await flurl.ShowList();
                        //await refit.getAllCategories();
<<<<<<< HEAD
                        //await servicestack.getAllCategories();
                        await myApiService.GetAllList();
=======
                        await servicestack.getAllCategories();
                        //Console.WriteLine("List of categories");
                        //await webClient.GetCategoriesList();
                        // await flurl.ShowList();
>>>>>>> main
                        break;
                    case 2:
                        Console.WriteLine("Enter Category's ID");
                        //await m.SearchAsync(Convert.ToInt32(Console.ReadLine()));
                        //await flurl.Show(Convert.ToInt32(Console.ReadLine()));
                        //await refit.GetCategory(Convert.ToInt32(Console.ReadLine()));
                        await myApiService.ShowcateById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 3:

                        Console.Write("Enter category Name: ");
                        //await m.InsertAsync(new Category {CategoryName = Console.ReadLine() });
                        //await rest.Post(new Category {CategoryName = Console.ReadLine() });
                        //await flurl.Add(new Category { CategoryName = Console.ReadLine() });
                        //await refit.CreateCategory(new Category { CategoryName = Console.ReadLine() });
                        //await servicestack.CreateCategory(new Category { CategoryName = Console.ReadLine() });
                        await myApiService.Insert(new Category { CategoryName = Console.ReadLine() });
                        break;
                    case 4:
                        Console.Write("Enter category id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter category Name: ");
                        name = Console.ReadLine();
                        //await refit.UpdateCategory(id, name);
<<<<<<< HEAD
                        //await servicestack.UpdateCategory(id, name);
                        await myApiService.Update(id, name);
=======
                        await servicestack.UpdateCategory(id, name);
                        //Console.WriteLine("Input Category");
                        //await webClient.UpdateCategory();
>>>>>>> main
                        break;
                    case 5:
                        Console.WriteLine("Enter Category's ID");
                        //await m.DeleteAsync(Convert.ToInt32(Console.ReadLine()));
<<<<<<< HEAD
                        //await refit.DeleteCategory(Convert.ToInt32(Console.ReadLine()));
                        await myApiService.Delete(Convert.ToInt32(Console.ReadLine()));
=======
                        await refit.DeleteCategory(Convert.ToInt32(Console.ReadLine()));
                        //Console.WriteLine("Input Category");
                        //await webClient.DeleteCategory();
>>>>>>> main
                        break;
                    case 6:

                        break;
                    default:
                        Console.WriteLine("Nothing");
                        break;
                }
            }
        }
    }
}
