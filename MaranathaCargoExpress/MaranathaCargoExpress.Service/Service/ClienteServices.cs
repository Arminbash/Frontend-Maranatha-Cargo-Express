using MaranathaCargoExpress.Service.Base;
using MaranathaCargoExpress.Service.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaranathaCargoExpress.Service.Service
{
    public class ClienteServices
    {
        public async Task<List<ClienteDto>> ListaCliente()
        {
            var request = await GenericMethodsAPIClient<List<ClienteDto>>.Get(ApiConnection.EndPoints.Cliente + "ObtenerCliente");
            return request;
        }
    }
}
