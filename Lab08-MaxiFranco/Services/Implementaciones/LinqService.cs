
using Lab08_MaxiFranco.Models.DTO;
using Lab08_MaxiFranco.Repositories;

namespace Lab08_MaxiFranco.Services.Implementaciones;

public class LinqService : ILinqService
{
    private readonly ILinqRepository _repository;
    private readonly IClientRepository _clientRepository;
    private readonly IOrderRepository _orderRepository;

    public LinqService(
        ILinqRepository repository,
        IClientRepository clientRepository,
        IOrderRepository orderRepository)
    {
        _repository = repository;
        _clientRepository = clientRepository;
        _orderRepository = orderRepository;
    }

    public Task<object> Ejercicio1(string nombre)
        => _repository.Ejercicio1(nombre);

    public Task<object> Ejercicio2(decimal precio)
        => _repository.Ejercicio2(precio);

    public Task<object> Ejercicio3(int orderId)
        => _repository.Ejercicio3(orderId);

    public Task<object> Ejercicio4(int orderId)
        => _repository.Ejercicio4(orderId);

    public Task<object> Ejercicio5()
        => _repository.Ejercicio5();

    public Task<object> Ejercicio6(DateTime fecha)
        => _repository.Ejercicio6(fecha);

    public Task<object> Ejercicio7()
        => _repository.Ejercicio7();

    public Task<object> Ejercicio8()
        => _repository.Ejercicio8();

    public Task<object> Ejercicio9()
        => _repository.Ejercicio9();

    public Task<object> Ejercicio10()
        => _repository.Ejercicio10();

    public Task<object> Ejercicio11(int clientId)
        => _repository.Ejercicio11(clientId);

    public Task<object> Ejercicio12(int productId)
        => _repository.Ejercicio12(productId);
    
    //
    //
    //
    //

    public Task<List<ClientOrderDto>> GetClientsWithOrdersAsync()
    {
        return _clientRepository.GetClientsWithOrdersAsync();
    }

    public Task<List<OrderDetailsDto>> GetOrderDetailsAsync()
    {
        return _orderRepository.GetOrderDetailsAsync();
    }

    public Task<List<ClientProductsDto>> GetClientProductsAsync()
    {
        return _clientRepository.GetClientProductsAsync();
    }

    public Task<List<SalesByClientDto>> GetSalesByClientAsync()
    {
        return _orderRepository.GetSalesByClientAsync();
    }
}
