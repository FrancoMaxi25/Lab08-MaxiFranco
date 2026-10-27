namespace Lab08_MaxiFranco.Models.DTO;

public class SalesByClientDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public decimal TotalSales { get; set; }
}