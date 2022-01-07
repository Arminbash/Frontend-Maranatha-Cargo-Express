using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MaranathaCargoExpress.Service.Base
{
    public class GenericMethodsAPIClient<T> where T : class
    {
        public async Task<T> Get(string endPoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(endPoint);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public async Task<T> GetById(string endPoint, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(endPoint+ $"/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public async Task<T> Post(string endPoint,object value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync(endPoint,value);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public async Task<T> Put(string endPoint,int id, object value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PutAsJsonAsync(endPoint + $"/{id}", value);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

        public async Task<T> Delete(string endPoint, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync(endPoint + $"/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await Task.FromResult<T>(null);
            }
        }

    }
}
