using Lab08_MaxiFranco.Models.DTO;
using Lab08_MaxiFranco.Repositories;

namespace Lab08_MaxiFranco.Services.Implementaciones;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<List<OrderDetailsDto>> GetOrderDetailsAsync()
    {
        return _orderRepository.GetOrderDetailsAsync();
    }

    public Task<List<SalesByClientDto>> GetSalesByClientAsync()
    {
        return _orderRepository.GetSalesByClientAsync();
    }
}