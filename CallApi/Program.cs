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
            int id;
            string name;
            while(true)
            {
                Console.WriteLine("1. Show List Category");
                Console.WriteLine("2. Search");
                Console.WriteLine("3. Insert");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Amongus: ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //await m.ShowList();
                        //await rest.ShowList();
                        //await flurl.ShowList();
                        //await refit.getAllCategories();
                        await servicestack.getAllCategories();
                        break;
                    case 2:
                        Console.WriteLine("Enter category");
                       
                        //await m.SearchAsync(Convert.ToInt32(Console.ReadLine()));
                        //await flurl.Show(Convert.ToInt32(Console.ReadLine()));
                        await refit.GetCategory(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 3:

                        Console.Write("Enter category Name: ");
                        //await m.InsertAsync(new Category {CategoryName = Console.ReadLine() });
                        //await rest.Post(new Category {CategoryName = Console.ReadLine() });
                        //await flurl.Add(new Category { CategoryName = Console.ReadLine() });
                        //await refit.CreateCategory(new Category { CategoryName = Console.ReadLine() });
                        await servicestack.CreateCategory(new Category { CategoryName = Console.ReadLine() });
                        break;
                    case 4:
                        Console.Write("Enter category id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter category Name: ");
                        name = Console.ReadLine();
                        //await refit.UpdateCategory(id, name);
                        await servicestack.UpdateCategory(id, name);
                        break;
                    case 5:
                        Console.WriteLine("Enter Category's ID");
                        //await m.DeleteAsync(Convert.ToInt32(Console.ReadLine()));
                        await refit.DeleteCategory(Convert.ToInt32(Console.ReadLine()));
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
