using MaranathaCargoExpress.Service.Base;
using MaranathaCargoExpress.Service.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaranathaCargoExpress.Service.Service
{
    public class ClienteServices
    {
        public async Task<List<ClienteDto>> ListaCliente(string token)
        {
            var request = await GenericMethodsAPIClient<List<ClienteDto>>.Get(ApiConnection.EndPoints.Cliente + "ObtenerCliente",token);
            return request;
        }
        public async Task<ClienteDto> AddClienteAsync(ClienteDto clienteDto,string token)
        {
            var request = await GenericMethodsAPIClient<ClienteDto>.Post(ApiConnection.EndPoints.Cliente + "CreateCliente", clienteDto ,token);
            return request;
        }

    }
}
