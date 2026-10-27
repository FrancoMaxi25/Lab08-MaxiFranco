using Lab08_MaxiFranco.Models.DTO;

namespace Lab08_MaxiFranco.Services;

public interface IOrderService
{
    Task<List<OrderDetailsDto>> GetOrderDetailsAsync();
    Task<List<SalesByClientDto>> GetSalesByClientAsync();
}