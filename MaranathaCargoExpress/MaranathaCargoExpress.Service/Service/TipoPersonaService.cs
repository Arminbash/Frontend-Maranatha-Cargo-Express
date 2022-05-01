using MaranathaCargoExpress.Service.Base;
using MaranathaCargoExpress.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaranathaCargoExpress.Service.Service
{
    public class TipoPersonaService
    {
        public async Task<List<TipoPersonaDto>> ListaTipoPersona(string token)
        {
            var request = await GenericMethodsAPIClient<List<TipoPersonaDto>>.Get(ApiConnection.EndPoints.TipoPersona + "ObtenerTipoPersona", token);
            return request;
        }
        public async Task<TipoPersonaDto> AddTipoPersonaAsync(TipoPersonaDto tipoPersonaDto, string token)
        {
            tipoPersonaDto.Estado = true;
            var request = await GenericMethodsAPIClient<TipoPersonaDto>.Post(ApiConnection.EndPoints.TipoPersona + "CreateTipoPersona", tipoPersonaDto, token);
            return request;
        }
        public async Task<TipoPersonaDto> ObtenerTipoPersona(int id, string token)
        {
            var request = await GenericMethodsAPIClient<TipoPersonaDto>.Get(ApiConnection.EndPoints.TipoPersona + "ObtenerTipoPersona/"+id.ToString(), token);
            return request;
        }

        public async Task<TipoPersonaDto> EditarTipoPersona(TipoPersonaDto tipoPersonaDto, string token)
        {
            var request = await GenericMethodsAPIClient<TipoPersonaDto>.Put(ApiConnection.EndPoints.TipoPersona + "UpdatetipoPersona",null,tipoPersonaDto, token);
            return request;
        }

        public async Task<TipoPersonaDto> EliminarTipoPersona(int id, string token)
        {
            var request = await GenericMethodsAPIClient<TipoPersonaDto>.Get(ApiConnection.EndPoints.TipoPersona + "ObtenerTipoPersona/"+id.ToString(), token);
            request.Estado = false;
            return await EditarTipoPersona(request, token);
        }
    }
}
