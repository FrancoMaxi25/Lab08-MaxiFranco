using Lab08_MaxiFranco.Models;
using Lab08_MaxiFranco.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Lab08_MaxiFranco.Repositories.Implementaciones;

public class OrderRepository : IOrderRepository
{
    private readonly Lab08DbContext context;

    public OrderRepository(Lab08DbContext context)
    {
        this.context = context;
    }

    public Task<List<OrderDetailsDto>> GetOrderDetailsAsync()
    {
        var ordersWithDetails = context.Orders
            .Include(order => order.Orderdetails)
            .ThenInclude(orderDetail => orderDetail.Product)
            .AsNoTracking()
            .Select(order => new OrderDetailsDto
            {
                OrderId = order.Orderid,
                OrderDate = order.Orderdate,
                Products = order.Orderdetails
                    .Select(od => new ProductDto
                    {
                        ProductName = od.Product.Name,
                        Quantity = od.Quantity,
                        Price = od.Product.Price
                    }).ToList()
            }).ToList();

        return Task.FromResult(ordersWithDetails);
    }

    public Task<List<SalesByClientDto>> GetSalesByClientAsync()
    {
        var salesByClient = context.Orders
            .Include(order => order.Orderdetails)
            .ThenInclude(orderDetail => orderDetail.Product)
            .AsNoTracking()
            .GroupBy(order => order.Clientid)
            .Select(group => new SalesByClientDto
            {
                ClientName = context.Clients
                    .FirstOrDefault(c => c.Clientid == group.Key)!.Name,
                TotalSales = group.Sum(order => order.Orderdetails
                    .Sum(detail => detail.Quantity * detail.Product.Price))
            })
            .OrderByDescending(s => s.TotalSales)
            .ToList();

        return Task.FromResult(salesByClient);
    }
}