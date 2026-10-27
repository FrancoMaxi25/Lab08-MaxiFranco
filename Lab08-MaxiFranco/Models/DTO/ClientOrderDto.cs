namespace Lab08_MaxiFranco.Models.DTO;

public class ClientOrderDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public List<OrderDto> Orders { get; set; } = new();
}