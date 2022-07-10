using MaranathaCargoExpress.Service.Base;
using MaranathaCargoExpress.Service.ViewModel;
using MaranathaCargoExpress.Service.ViewModel.Base;
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
        public async Task<PaginationRequestBase<ClientViewModel>> ListaClientePaginado(PaginationDto pagination, string token)
        {
            var request = await GenericMethodsAPIClient<PaginationRequestBase<ClientViewModel>>.Post(ApiConnection.EndPoints.Cliente + "ObtenerClientePaginado", pagination, token);
            return request;
        }
        public async Task<ClienteDto> EditarCliente(ClienteDto clienteDto, string token)
        {
            var request = await GenericMethodsAPIClient<ClienteDto>.Put(ApiConnection.EndPoints.Cliente + "UpdateCliente", null, clienteDto, token);
            return request;
        }
        public async Task<ClienteDto> EliminarCliente(int id, string token)
        {
            var request = await GenericMethodsAPIClient<ClienteDto>.Get(ApiConnection.EndPoints.Cliente + "ObtenerCliente/" + id.ToString(), token);
            request.Estado = false;
            return await EditarCliente(request, token);
        }
        public async Task<ClientViewModel> ObtenerCliente(int id, string token)
        {
            var request = await GenericMethodsAPIClient<ClientViewModel>.Get(ApiConnection.EndPoints.Cliente + "ObtenerCliente/" + id.ToString(), token);
            return request;
        }
    }
}
