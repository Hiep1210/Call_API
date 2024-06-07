using slot_4.Models;

namespace CallApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Manager m = new Manager();
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
                        await m.ShowList();
                        break;
                    case 2:
                        Console.WriteLine("Enter Category's ID");
                        await m.SearchAsync(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine("Enter category");
                        await m.InsertAsync(new Category {CategoryName = Console.ReadLine() });
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        Console.WriteLine("Enter Category's ID");
                        await m.DeleteAsync(Convert.ToInt32(Console.ReadLine()));
                        break;
                    default:
                        Console.WriteLine("Nothing");
                        break;
                }
            }
        }
    }
}
