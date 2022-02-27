using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MaranathaCargoExpress.Service.Base
{
    public static class GenericMethodsAPIClient<T> where T : class
    {
        public static async Task<T> Get(string endPoint, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null) client.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", token);

                var response = client.GetAsync(endPoint).Result;
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var cuerpo = await response.Content.ReadAsStringAsync();
                    var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

                    foreach (var campoErrores in erroresDelAPI)
                    {
                        Console.WriteLine($"-{campoErrores.Key}");
                        foreach (var error in campoErrores.Value)
                        {
                            Console.WriteLine($"  {error}");
                        }
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public static async Task<T> GetById(string endPoint, int id,string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null) client.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", token);

                var response = client.GetAsync(endPoint + $"/{id}").Result;
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var cuerpo = await response.Content.ReadAsStringAsync();
                    var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

                    foreach (var campoErrores in erroresDelAPI)
                    {
                        Console.WriteLine($"-{campoErrores.Key}");
                        foreach (var error in campoErrores.Value)
                        {
                            Console.WriteLine($"  {error}");
                        }
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public static async Task<T> Post(string endPoint, object value,string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null) client.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", token);

                var response = client.PostAsJsonAsync(endPoint, value).Result;
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var cuerpo = await response.Content.ReadAsStringAsync();
                    var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

                    foreach (var campoErrores in erroresDelAPI)
                    {
                        Console.WriteLine($"-{campoErrores.Key}");
                        foreach (var error in campoErrores.Value)
                        {
                            Console.WriteLine($"  {error}");
                        }
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public static async Task<T> Put(string endPoint, int id, object value, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null) client.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", token);

                var response = client.PutAsJsonAsync(endPoint + $"/{id}", value).Result;
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var cuerpo = await response.Content.ReadAsStringAsync();
                    var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

                    foreach (var campoErrores in erroresDelAPI)
                    {
                        Console.WriteLine($"-{campoErrores.Key}");
                        foreach (var error in campoErrores.Value)
                        {
                            Console.WriteLine($"  {error}");
                        }
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public static async Task<T> Delete(string endPoint, int id, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null) client.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", token);

                var response = client.DeleteAsync(endPoint + $"/{id}").Result;
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var cuerpo = await response.Content.ReadAsStringAsync();
                    var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

                    foreach (var campoErrores in erroresDelAPI)
                    {
                        Console.WriteLine($"-{campoErrores.Key}");
                        foreach (var error in campoErrores.Value)
                        {
                            Console.WriteLine($"  {error}");
                        }
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

    }
}

//public static async Task<T> Post(string endPoint, object value)
//{
//    var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
//    var url = ApiConnection.ApiUrl + endPoint;
//    using (var client = new HttpClient())
//    {
//        var response = client.PostAsJsonAsync(url, value).Result;
//        if (response.StatusCode == HttpStatusCode.BadRequest)
//        {
//            var cuerpo = await response.Content.ReadAsStringAsync();
//            var erroresDelAPI = APIUtil.ExtraerErroresDelWebAPI(cuerpo);

//            foreach (var campoErrores in erroresDelAPI)
//            {
//                Console.WriteLine($"-{campoErrores.Key}");
//                foreach (var error in campoErrores.Value)
//                {
//                    Console.WriteLine($"  {error}");
//                }
//            }
//        }
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadAsAsync<T>();
//        }
//        return await Task.FromResult<T>(null);
//    }
//}
