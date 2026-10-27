using Lab08_MaxiFranco.Models.DTO;

namespace Lab08_MaxiFranco.Services;

public interface IClientService
{
    Task<IEnumerable<ClienteDtos>> GetAllAsync();
    Task<ClienteDtos?> GetByIdAsync(int id);
    Task<ClienteDtos> CreateAsync(ClienteDto dto);
    Task<bool> UpdateAsync(int id, ClienteDto dto);
    Task<bool> DeleteAsync(int id);

    Task<List<ClientOrderDto>> GetClientsWithOrdersAsync();
    Task<List<ClientProductsDto>> GetClientProductsAsync();
}