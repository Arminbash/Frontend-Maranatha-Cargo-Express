using MaranathaCargoExpress.Service.Base;
using MaranathaCargoExpress.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaranathaCargoExpress.Service.Service
{
    public class TypeClientService
    {
        public async Task<List<TipoClienteDto>> ListTypeClient(string token)
        {
            var resquest = await GenericMethodsAPIClient<List<TipoClienteDto>>.Get(ApiConnection.EndPoints.TipoCliente + "ObtenerTipoCliente", token);
            return resquest;
        }
        public async Task<TipoClienteDto> AddTypeClientAsync(TipoClienteDto tipoClienteDto, string token)
        {
            tipoClienteDto.Estado = true;
            var request = await GenericMethodsAPIClient<TipoClienteDto>.Post(ApiConnection.EndPoints.TipoCliente + "CreateTipoCliente", tipoClienteDto,token);
            return request;
        }
        public async Task<TipoClienteDto> GetTipoCliente(int id, string token)
        {
            var request = await GenericMethodsAPIClient<TipoClienteDto>.Get(ApiConnection.EndPoints.TipoCliente + "ObtenerTipoCliente/" + id.ToString(), token);
            return request;
        }
        public async Task<TipoClienteDto> UpdateTypeClient(TipoClienteDto tipoClienteDto, string token)
        {
            var request = await GenericMethodsAPIClient<TipoClienteDto>.Put(ApiConnection.EndPoints.TipoCliente + "UpdatetipoCliente",null,tipoClienteDto, token);
            return request;
        }

        public async Task<TipoClienteDto> DeleteTypeClient(int id, string token)
        {
            var request = await GenericMethodsAPIClient<TipoClienteDto>.Get(ApiConnection.EndPoints.TipoCliente + "ObtenerTipoCliente/" + id.ToString(), token);
            request.Estado = false;
            return await UpdateTypeClient(request, token);

        }
       
    }
}
