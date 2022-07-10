using MaranathaCargoExpress.Service.Base;
using MaranathaCargoExpress.Service.ViewModel;
using MaranathaCargoExpress.Service.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaranathaCargoExpress.Service.Service
{
  public  class PersonService
    {
        public async Task<List<PersonaDto>> ListaPersona(string token)
        {
            var request = await GenericMethodsAPIClient<List<PersonaDto>>.Get(ApiConnection.EndPoints.Persona + "ObtenerPersona", token);
            return request;
        }
        public async Task<PersonaDto> AddPersonaAsync(PersonaDto personaDto, string token)
        {
            personaDto.Estado = true;
            var request = await GenericMethodsAPIClient<PersonaDto>.Post(ApiConnection.EndPoints.Persona + "CreatePersona", personaDto, token);
            return request;
        }
        public async Task<PersonaDto> ObtenerPersona(int id, string token)
        {
            var request = await GenericMethodsAPIClient<PersonaDto>.Get(ApiConnection.EndPoints.Persona + "ObtenerPersona/" + id.ToString(), token);
            return request;
        }

        public async Task<PersonaDto> EditarPersona(PersonaDto personaDto, string token)
        {
            var request = await GenericMethodsAPIClient<PersonaDto>.Put(ApiConnection.EndPoints.Persona + "UpdatePersona", null, personaDto, token);
            return request;
        }
        public async Task<PersonaDto> EliminarPersona(int id, string token)
        {
            var request = await GenericMethodsAPIClient<PersonaDto>.Get(ApiConnection.EndPoints.Persona + "ObtenerPersona/" + id.ToString(), token);
            request.Estado = false;
            return await EditarPersona(request, token);
        }
        public async Task<PaginationRequestBase<PersonViewModel>> ListPersonPagination(PaginationDto pagination, string token)
        {
            var request = await GenericMethodsAPIClient<PaginationRequestBase<PersonViewModel>>.Post(ApiConnection.EndPoints.Persona + "ObtenerPersonaPaginado", pagination, token);
            return request;
        }
    }
}
