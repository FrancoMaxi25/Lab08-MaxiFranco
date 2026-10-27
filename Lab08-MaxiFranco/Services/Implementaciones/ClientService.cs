
using Lab08_MaxiFranco.Models;
using Lab08_MaxiFranco.Models.DTO;
using Lab08_MaxiFranco.Repositories;

namespace Lab08_MaxiFranco.Services.Implementaciones;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClientRepository _clientRepository;

    public ClientService(
        IUnitOfWork unitOfWork,
        IClientRepository clientRepository)
    {
        _unitOfWork = unitOfWork;
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<ClienteDtos>> GetAllAsync()
    {
        try
        {
            var clientes = await _unitOfWork
                .Repository<Client>()
                .GetAllAsync();

            return clientes.Select(c => new ClienteDtos
            {
                Clientid = c.Clientid,
                Name = c.Name,
                Email = c.Email
            });
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener los clientes", ex);
        }
    }

    public async Task<ClienteDtos?> GetByIdAsync(int id)
    {
        try
        {
            var cliente = await _unitOfWork
                .Repository<Client>()
                .GetByIdAsync(id);

            if (cliente == null)
                return null;

            return new ClienteDtos
            {
                Clientid = cliente.Clientid,
                Name = cliente.Name,
                Email = cliente.Email
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener el cliente", ex);
        }
    }

    public async Task<ClienteDtos> CreateAsync(ClienteDto dto)
    {
        try
        {
            var cliente = new Client
            {
                Name = dto.Name,
                Email = dto.Email
            };

            await _unitOfWork
                .Repository<Client>()
                .InsertAsync(cliente);

            await _unitOfWork.Complete();

            return new ClienteDtos
            {
                Clientid = cliente.Clientid,
                Name = cliente.Name,
                Email = cliente.Email
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Error al crear el cliente", ex);
        }
    }

    public async Task<bool> UpdateAsync(int id, ClienteDto dto)
    {
        try
        {
            var cliente = await _unitOfWork
                .Repository<Client>()
                .GetByIdAsync(id);

            if (cliente == null)
                return false;

            cliente.Name = dto.Name;
            cliente.Email = dto.Email;

            await _unitOfWork
                .Repository<Client>()
                .UpdateAsync(cliente);

            await _unitOfWork.Complete();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar el cliente", ex);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var cliente = await _unitOfWork
                .Repository<Client>()
                .GetByIdAsync(id);

            if (cliente == null)
                return false;

            await _unitOfWork
                .Repository<Client>()
                .DeleteAsync(cliente);

            await _unitOfWork.Complete();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar el cliente", ex);
        }
    }

    public Task<List<ClientOrderDto>> GetClientsWithOrdersAsync()
    {
        return _clientRepository.GetClientsWithOrdersAsync();
    }

    public Task<List<ClientProductsDto>> GetClientProductsAsync()
    {
        return _clientRepository.GetClientProductsAsync();
    }
}
