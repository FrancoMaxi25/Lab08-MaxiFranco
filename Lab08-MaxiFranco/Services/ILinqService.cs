using Lab08_MaxiFranco.Models.DTO;

namespace Lab08_MaxiFranco.Services;

public interface ILinqService
{
    Task<object> Ejercicio1(string nombre);
    Task<object> Ejercicio2(decimal precio);
    Task<object> Ejercicio3(int orderId);
    Task<object> Ejercicio4(int orderId);
    Task<object> Ejercicio5();
    Task<object> Ejercicio6(DateTime fecha);
    Task<object> Ejercicio7();
    Task<object> Ejercicio8();
    Task<object> Ejercicio9();
    Task<object> Ejercicio10();
    Task<object> Ejercicio11(int clientId);
    Task<object> Ejercicio12(int productId);

    Task<List<ClientOrderDto>> GetClientsWithOrdersAsync();

    Task<List<OrderDetailsDto>> GetOrderDetailsAsync();
    Task<List<ClientProductsDto>> GetClientProductsAsync();
    Task<List<SalesByClientDto>> GetSalesByClientAsync();
}