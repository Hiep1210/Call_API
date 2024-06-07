
using slot_4.Models;
using System;
using System.Text.Json;

namespace CallApi
{
    internal class Manager
    {
        public Manager()
        {
        }

        string link = "http://localhost:5000/api/Category";

        internal async Task ShowList()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        List<Category> categories = JsonSerializer.Deserialize<List<Category>>(data);
                        Display(categories);
                    }
                }
            }
        }
        internal async Task InsertAsync(Category category)
        {
            try
            {
                string json = JsonSerializer.Serialize(category);
                HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.PostAsync(link, content))
                    {
                        Console.WriteLine(res.StatusCode + "Created " + res.Content);
                    }
                }
            }
            catch (Exception e)
            {
                // Handle any errors that might have occurred
                Console.WriteLine("Request error: " + e.Message);
            }
        }
        private void Display(List<Category> categories)
        {
            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }
        }

        internal async Task SearchAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync($"{link}/id?id={id}"))
                {
                    if (!res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Not Found");
                        return;
                    }
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        Category categories = JsonSerializer.Deserialize<Category>(data);
                        Console.WriteLine(categories);
                    }

                }
            }
        }

        internal async Task DeleteAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync($"{link}/id?id={id}"))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Delete Ok");
                    }
                }
            }
        }
    }
}