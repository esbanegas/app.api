using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Core;
using app.api.Services.ClientService;
using app.api.Services.ClientService.Dto;
using app.api.Services.ClientService.Request;
using Microsoft.AspNetCore.Mvc;

namespace app.api.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            ThrowIf.Argument.IsNull(clientAppService, nameof(clientAppService));

            _clientAppService = clientAppService;
        }

        [HttpGet("all")]
        public async Task<List<ClientDto>> GetAllAync()
        {
            return await _clientAppService.GetAllAsync();
        }

        [HttpGet("{idClient:int}")]
        public async Task<ClientDto> GetSingleAync(int idClient)
        {
            return await _clientAppService.GetSingleAsync(idClient);
        }

        [HttpPost]
        public async Task<ClientDto> AddAsync(ClientRequest request)
        {
            return await _clientAppService.AddAsync(request);
        }

        [HttpDelete("{clientId:int}")]
        public async Task<ClientDto> RemoveAsync(int clientId)
        {
            return await _clientAppService.RemoveAsync(clientId);
        }
        
        [HttpPut]
        public async Task<ClientDto> ModifyAsync(ClientRequest request)
        {
            return await _clientAppService.ModifyAsync(request);
        }
    }
}