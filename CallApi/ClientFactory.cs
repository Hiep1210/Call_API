using Newtonsoft.Json;
using slot_4.Models;
using System.Net.Http.Json;

namespace CallApi
{
    public class ClientFactory
    {
        private static string link = "http://localhost:5000/api";

        private readonly HttpClient _httpClient;

        public ClientFactory()
        {
        }

        public ClientFactory(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        private void Display(params Category[] categories)
        {
            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }
        }
        public async Task GetAllList()
        {

            var response = await _httpClient.GetAsync(link + "/Category");
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            List<Category> Categories = JsonConvert.DeserializeObject<List<Category>>(json);
            Display(Categories.ToArray());

        }
        internal async Task ShowcateById(int id)
        {
            var response = await _httpClient.GetAsync(link + "/Category/" + id);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            Category Categories = JsonConvert.DeserializeObject<Category>(json);
            Display(Categories);
        }
        internal async Task Insert(Category? ca)
        {
            var response = await _httpClient.PostAsJsonAsync(link + "/Category", ca);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            Category Categories = JsonConvert.DeserializeObject<Category>(json);
            Display(Categories);
        }
        internal async Task Update(int id, string name)
        {
            var ca = new Category()
            {
                CategoryId = id,
                CategoryName = name
            };
            var response = await _httpClient.PutAsJsonAsync(link + "/Category", ca);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            Category Categories = JsonConvert.DeserializeObject<Category>(json);
            Display(Categories);
        }
        internal async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync(link + "/Category/" + id);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            Category Categories = JsonConvert.DeserializeObject<Category>(json);
            Display(Categories);
        }
    }

}
