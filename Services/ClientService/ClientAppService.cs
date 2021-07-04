using System.Collections.Generic;
using System.Threading.Tasks;
using app.api.Core;
using app.api.DataContext;
using app.api.DataContext.Models;
using app.api.DataContext.Repository;
using app.api.Services.ClientService.Dto;
using app.api.Services.ClientService.Request;

namespace app.api.Services.ClientService
{
    public class ClientAppService : IClientAppService
    {
        private readonly IGenericRepository<DBDataContext> _genericRepository;

        public ClientAppService(IGenericRepository<DBDataContext> clientRepository)
        {
            ThrowIf.Argument.IsNull(clientRepository, nameof(clientRepository));

            _genericRepository = clientRepository;
        }

        public async Task<List<ClientDto>> GetAllAsync()
        {
            List<Client> clients = await _genericRepository.GetAllAsync<Client>();

            return clients.ProjectedAsCollection<ClientDto>();
        }

        public async Task<ClientDto> GetSingleAsync(int idClient)
        {
            ThrowIf.Argument.IsNull(idClient, nameof(idClient));

            Client client = await _genericRepository.GetSingleAsync<Client>(client => client.IdClient == idClient);

            if (client == null)
            {
                return new ClientDto { FullName = "Not found" };
            }

            return client.ProjectedAsItem<ClientDto>();
        }

        public async Task<ClientDto> AddAsync(ClientRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));

            Client newClient = new Client
            {
                Identifier = request.Identifier,
                FullName = request.FullName,
                State = request.State
            };

            _genericRepository.Add(newClient);

            await _genericRepository.UnitOfWork.Commit();

            return new ClientDto();
        }

        public async Task<ClientDto> RemoveAsync(int clientId)
        {
            ThrowIf.Argument.IsNull(clientId, nameof(clientId));

            Client client = await _genericRepository.GetSingleAsync<Client>(s => s.IdClient == clientId);

            if (client == null) return NotFount();

            _genericRepository.Remove<Client>(client);

            await _genericRepository.UnitOfWork.Commit();

            return new ClientDto();
        }

        public async Task<ClientDto> ModifyAsync(ClientRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));
            ThrowIf.Argument.IsNull(request.IdClient, nameof(request.IdClient));

            Client client = await _genericRepository.GetSingleAsync<Client>(s => s.IdClient == request.IdClient);

            if (client == null) return NotFount();

            client.Identifier = request.Identifier;
            client.FullName = request.FullName;
            client.State = request.State;

            await _genericRepository.UnitOfWork.Commit();

            return new ClientDto
            {
                Code = 200,
                Message = "Client is modified"
            };
        }

        private ClientDto NotFount()
        {
            return new ClientDto
            {
                Code = 404,
                Message = "El detalle de factura no existe."
            };
        }
    }
}