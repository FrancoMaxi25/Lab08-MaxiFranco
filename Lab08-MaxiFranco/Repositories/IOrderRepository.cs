using Lab08_MaxiFranco.Models.DTO;

namespace Lab08_MaxiFranco.Repositories;

public interface IOrderRepository
{
    Task<List<OrderDetailsDto>> GetOrderDetailsAsync();
    Task<List<SalesByClientDto>> GetSalesByClientAsync();
}