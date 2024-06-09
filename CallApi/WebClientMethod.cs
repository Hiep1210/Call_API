using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using slot_4.Models;
using static ServiceStack.Diagnostics.Events;

namespace CallApi
{
    internal class WebClientMethod
    {
        public WebClientMethod() { }


        public async Task<List<Category>> GetCategoriesList()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = RestSharpMethod.link;
                    var url = new Uri(webClient.BaseAddress + "/Category");
                    var json = await webClient.DownloadStringTaskAsync(url);

                    var list = JsonConvert.DeserializeObject<List<Category>>(json);
                    Display(list.ToArray());
                    return list.ToList();
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }

        public async Task UpdateCategory()
        {

            Category c = new Category();
            Console.Write("a. Enter an category id");
            c.CategoryId = int.Parse(Console.ReadLine());
            Console.Write("b. Enter an category name");
            c.CategoryName = Console.ReadLine();


            try
            {

                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = RestSharpMethod.link;
                    var url = new Uri(webClient.BaseAddress + "/Category");
                    var data = JsonConvert.SerializeObject(c);
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var response = await webClient.UploadStringTaskAsync(url, WebRequestMethods.Http.Put, data);
                    var categoryObjectAfterUpdated = JsonConvert.DeserializeObject<Category>(response);
                    Console.WriteLine("c. Category after updated");
                    Display(categoryObjectAfterUpdated);
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }

        public async Task DeleteCategory()
        {
            int id;
            Console.WriteLine("a. Enter an category id");
            id = int.Parse(Console.ReadLine());


            try
            {
                var url = RestSharpMethod.link + $"/Category/{id}";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json";
                request.Method = "DELETE";


                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine("Delete successful.");

                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            string jsonString = reader.ReadToEnd();


                            var categoryObjectAfterDelete = JsonConvert.DeserializeObject<Category>(jsonString);
                            Console.WriteLine("b. Category deleted successfully.");
                            Display(categoryObjectAfterDelete);

                        }
                    }
                    else
                    {
                        Console.WriteLine($"Unexpected status code: {response.StatusCode}");
                    }
                }

            }
            catch (WebException ex)
            {
                throw ex;
            }

        }

        private void Display(params Category[] categories)
        {
            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }
        }

    }
}
