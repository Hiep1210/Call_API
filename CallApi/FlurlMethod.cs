using Flurl;
using Flurl.Http;
using slot_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallApi
{
    internal class FlurlMethod
    {
        private string link = "http://localhost:5000/api";
        internal async Task ShowList()
        {
            try
            {
                var serializer = new Flurl.Http.Newtonsoft.NewtonsoftJsonSerializer();
                List<Category> cat = await link.AppendPathSegment("Category")
                    .WithSettings(s => s.JsonSerializer = serializer)
                    .GetJsonAsync<List<Category>>();
                Display(cat.ToArray());
            }
            catch (FlurlHttpException ex)
            {
                var err = await ex.GetResponseJsonAsync<Exception>(); // or GetResponseStringAsync(), etc.
                Console.WriteLine($"Error returned from {ex.Call.Request.Url}: {err.Message}");
            }
        }

        internal async Task Show(int id)
        {
            try
            {
                var serializer = new Flurl.Http.Newtonsoft.NewtonsoftJsonSerializer();
                Category cat = await link.AppendPathSegments("Category", "id")
                    .WithSettings(s => s.JsonSerializer = serializer)
                    .AppendQueryParam("id", id)
                    .GetJsonAsync<Category>();
                Display(cat);
            }
            catch (FlurlHttpException ex)
            {
                var err = await ex.GetResponseStringAsync(); // or GetResponseStringAsync(), etc.
                Console.WriteLine($"Error returned from {ex.Call.Request.Url}: {err}");
            }catch(Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
            }
        }
        internal async Task Add(Category cate)
        {
            try
            {
                var serializer = new Flurl.Http.Newtonsoft.NewtonsoftJsonSerializer();
                Category cat = await link.AppendPathSegments("Category")
                    .WithOAuthBearerToken("token")
                    .WithSettings(s => s.JsonSerializer = serializer)
                    .PostJsonAsync(cate)
                    .ReceiveJson<Category>();
                Display(cat);
            }
            catch (FlurlHttpException ex)
            {
                var err = await ex.GetResponseJsonAsync<Exception>(); // or GetResponseStringAsync(), etc.
                Console.WriteLine($"Error returned from {ex.Call.Request.Url}: {err.Message}");
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
