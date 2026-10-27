using Lab08_MaxiFranco.Models;
using Lab08_MaxiFranco.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Lab08_MaxiFranco.Repositories.Implementaciones;

public class ClientRepository : IClientRepository
{
    private readonly Lab08DbContext context;

    public ClientRepository(Lab08DbContext context)
    {
        this.context = context;
    }

    public Task<List<ClientOrderDto>> GetClientsWithOrdersAsync()
    {
        var clientOrders = context.Clients
            .AsNoTracking()
            .Select(client => new ClientOrderDto
            {
                ClientName = client.Name,
                Orders = client.Orders
                    .Select(order => new OrderDto
                    {
                        OrderId = order.Orderid,
                        OrderDate = order.Orderdate
                    }).ToList()
            }).ToList();

        return Task.FromResult(clientOrders);
    }

    public Task<List<ClientProductsDto>> GetClientProductsAsync()
    {
        var clientsWithProductCount = context.Clients
            .AsNoTracking()
            .Select(client => new ClientProductsDto
            {
                ClientName = client.Name,
                TotalProducts = client.Orders
                    .Sum(order => order.Orderdetails
                        .Sum(detail => detail.Quantity))
            })
            .ToList();

        return Task.FromResult(clientsWithProductCount);
    }
}