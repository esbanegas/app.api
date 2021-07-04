using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Services.ClientService.Dto;
using app.api.Services.ClientService.Request;

namespace app.api.Services.ClientService
{
    public interface IClientAppService
    {
        Task<ClientDto> GetSingleAsync(int idClient);
        Task<List<ClientDto>> GetAllAsync();
        Task<ClientDto> AddAsync(ClientRequest request);
        Task<ClientDto> RemoveAsync(int clientId);
        Task<ClientDto> ModifyAsync(ClientRequest request);
    }
}