using Lab08_MaxiFranco.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab08_MaxiFranco.Repositories.Implementaciones;

public class LinqRepository : ILinqRepository
{
    private readonly IGenericRepository<Client> _clients;
    private readonly IGenericRepository<Product> _products;
    private readonly IGenericRepository<Order> _orders;
    private readonly IGenericRepository<Orderdetail> _details;

    public LinqRepository(
        IGenericRepository<Client> clients,
        IGenericRepository<Product> products,
        IGenericRepository<Order> orders,
        IGenericRepository<Orderdetail> details)
    {
        _clients = clients;
        _products = products;
        _orders = orders;
        _details = details;
    }
    public async Task<object> Ejercicio1(string nombre)
    {
        return await _clients.GetQueryable()
            .Where(c => c.Name.StartsWith(nombre))
            .ToListAsync();
    }
    public async Task<object> Ejercicio2(decimal precio)
    {
        return await _products.GetQueryable()
            .Where(p => p.Price > precio)
            .ToListAsync();
    }
    public async Task<object> Ejercicio3(int orderId)
    {
        return await _details.GetQueryable()
            .Where(d => d.Orderid == orderId)
            .Select(d => new
            {
                OrderId = d.Orderid,
                ProductName = d.Product.Name,
                d.Quantity
            })
            .ToListAsync();
    }
    public async Task<object> Ejercicio4(int orderId)
    {
        var total = await _details.GetQueryable()
            .Where(d => d.Orderid == orderId)
            .SumAsync(d => d.Quantity);

        return new
        {
            OrderId = orderId,
            TotalQuantity = total
        };
    }
    public async Task<object> Ejercicio5()
    {
        return (object?)await _products.GetQueryable()
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync()
            ?? new { Message = "No hay productos registrados" };
    }
    public async Task<object> Ejercicio6(DateTime fecha)
    {
        fecha = DateTime.SpecifyKind(
            fecha, DateTimeKind.Unspecified);

        return await _orders.GetQueryable()
            .Where(o => o.Orderdate > fecha)
            .ToListAsync();
    }
    public async Task<object> Ejercicio7()
    {
        var promedio = await _products.GetQueryable()
            .Select(p => (decimal?)p.Price)
            .AverageAsync();

        return new
        {
            AveragePrice = promedio
        };
    }
    public async Task<object> Ejercicio8()
    {
        return await _products.GetQueryable()
            .Where(p => p.Description == null ||
                        p.Description == "")
            .ToListAsync();
    }
    public async Task<object> Ejercicio9()
    {
        return (object?)await _orders.GetQueryable()
            .GroupBy(o => o.Clientid)
            .Select(g => new
            {
                ClientId = g.Key,
                TotalOrders = g.Count()
            })
            .OrderByDescending(x => x.TotalOrders)
            .FirstOrDefaultAsync()
            ?? new { Message = "No hay pedidos registrados" };
    }
    public async Task<object> Ejercicio10()
    {
        return await _details.GetQueryable()
            .Select(d => new
            {
                OrderId = d.Orderid,
                ProductName = d.Product.Name,
                d.Quantity
            })
            .OrderBy(d => d.OrderId)
            .ToListAsync();
    }
    public async Task<object> Ejercicio11(int clientId)
    {
        return await _details.GetQueryable()
            .Where(d => d.Order.Clientid == clientId)
            .Select(d => new
            {
                ClientId = d.Order.Clientid,
                OrderId = d.Orderid,
                ProductName = d.Product.Name,
                d.Quantity
            })
            .ToListAsync();
    }
    public async Task<object> Ejercicio12(int productId)
    {
        return await _details.GetQueryable()
            .Where(d => d.Productid == productId)
            .Select(d => new
            {
                ClientId = d.Order.Clientid,
                ClientName = d.Order.Client.Name
            })
            .Distinct()
            .ToListAsync();
    }
}
