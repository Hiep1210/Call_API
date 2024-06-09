using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.NewtonsoftJson;
using slot_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CallApi
{
    internal class RestSharpMethod
    {
        private static string link = "http://localhost:5000/api";
        internal async Task ShowList()
        {
            try
            {
                var client = new RestClient(configureSerialization: s => s.UseNewtonsoftJson());
                List<Category> res = await client.GetJsonAsync<List<Category>>(link + "/Category");
                Display(res);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("Exception : " + ex.Message);
            }
        }

        //internal async Task ShowList()
        //{
        //    try
        //    {
        //        var options = new RestClientOptions(link)
        //        {
        //            Authenticator = new HttpBasicAuthenticator("username", "password")
        //        };
        //        //var client = new RestClient(configureSerialization: s => s.UseNewtonsoftJson());
        //        //List<Category> res = await client.GetJsonAsync<List<Category>>(link + "/Category");
        //        var client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
        //        List<Category> res = await client.GetJsonAsync<List<Category>>("/Category");
        //        Display(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        await Console.Out.WriteLineAsync("Exception : " + ex.Message);
        //    }
        //}

        internal async Task Post(Category cat)
        {
            try
            {
                var client = new RestClient(configureSerialization: s => s.UseNewtonsoftJson());
                var res = await client.PostJsonAsync<Category>(link + "/Category", cat);
                await Console.Out.WriteLineAsync(res.ToString());
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("Exception : " + ex.Message);
            }
        }

        private void Display(List<Category> categories)
        {
            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }
        }
    }
}

