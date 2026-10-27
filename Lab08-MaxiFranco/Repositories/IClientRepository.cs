using Lab08_MaxiFranco.Models.DTO;

namespace Lab08_MaxiFranco.Repositories;

public interface IClientRepository
{
    Task<List<ClientOrderDto>> GetClientsWithOrdersAsync();
    Task<List<ClientProductsDto>> GetClientProductsAsync();
}