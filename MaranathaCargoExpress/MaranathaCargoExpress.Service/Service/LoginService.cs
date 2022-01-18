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
            var request = await GenericMethodsAPIClient<UsuarioDto>.Post(ApiConnection.EndPoints.Usuario+"login", new { Email = Email, Password = Password });
            return request;
        } 
    }
}
