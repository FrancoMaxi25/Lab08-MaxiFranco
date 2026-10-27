
using Lab08_MaxiFranco.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_MaxiFranco.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LinqController : ControllerBase
{
    private readonly ILinqService _service;

    public LinqController(ILinqService service)
    {
        _service = service;
    }

    [HttpGet("ejercicio1")]
    public async Task<IActionResult> Ejercicio1(string nombre = "Juan")
    {
        return Ok(await _service.Ejercicio1(nombre));
    }

    [HttpGet("ejercicio2")]
    public async Task<IActionResult> Ejercicio2(decimal precio = 20)
    {
        return Ok(await _service.Ejercicio2(precio));
    }

    [HttpGet("ejercicio3")]
    public async Task<IActionResult> Ejercicio3(int orderId = 1)
    {
        return Ok(await _service.Ejercicio3(orderId));
    }

    [HttpGet("ejercicio4")]
    public async Task<IActionResult> Ejercicio4(int orderId = 1)
    {
        return Ok(await _service.Ejercicio4(orderId));
    }

    [HttpGet("ejercicio5")]
    public async Task<IActionResult> Ejercicio5()
    {
        return Ok(await _service.Ejercicio5());
    }

    [HttpGet("ejercicio6")]
    public async Task<IActionResult> Ejercicio6(DateTime fecha)
    {
        return Ok(await _service.Ejercicio6(fecha));
    }

    [HttpGet("ejercicio7")]
    public async Task<IActionResult> Ejercicio7()
    {
        return Ok(await _service.Ejercicio7());
    }

    [HttpGet("ejercicio8")]
    public async Task<IActionResult> Ejercicio8()
    {
        return Ok(await _service.Ejercicio8());
    }

    [HttpGet("ejercicio9")]
    public async Task<IActionResult> Ejercicio9()
    {
        return Ok(await _service.Ejercicio9());
    }

    [HttpGet("ejercicio10")]
    public async Task<IActionResult> Ejercicio10()
    {
        return Ok(await _service.Ejercicio10());
    }

    [HttpGet("ejercicio11")]
    public async Task<IActionResult> Ejercicio11(int clientId = 1)
    {
        return Ok(await _service.Ejercicio11(clientId));
    }

    [HttpGet("ejercicio12")]
    public async Task<IActionResult> Ejercicio12(int productId = 2)
    {
        return Ok(await _service.Ejercicio12(productId));
    }

    [HttpGet("lab9/clientes-pedidos")]
    public async Task<IActionResult> GetClientsWithOrders()
    {
        return Ok(await _service.GetClientsWithOrdersAsync());
    }

    [HttpGet("lab9/detalles-pedidos")]
    public async Task<IActionResult> GetOrderDetails()
    {
        return Ok(await _service.GetOrderDetailsAsync());
    }

    [HttpGet("lab9/productos-clientes")]
    public async Task<IActionResult> GetClientProducts()
    {
        return Ok(await _service.GetClientProductsAsync());
    }

    [HttpGet("lab9/ventas-clientes")]
    public async Task<IActionResult> GetSalesByClient()
    {
        return Ok(await _service.GetSalesByClientAsync());
    }
}
