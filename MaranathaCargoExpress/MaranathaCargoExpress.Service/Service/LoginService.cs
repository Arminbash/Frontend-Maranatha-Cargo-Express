using MaranathaCargoExpress.Service.Base;
using MaranathaCargoExpress.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MaranathaCargoExpress.Service.Service
{
    public class LoginService
    {
        public async Task<UsuarioDto> Login(string Email, string Password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConnection.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(ApiConnection.EndPoints.Usuario);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<UsuarioDto>();
                }
                return await Task.FromResult<UsuarioDto>(null);
            }
        } 
    }
}
