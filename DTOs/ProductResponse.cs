namespace CSharpProductPractice.DTOs;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Price { get; set; }
    public int StockQty { get; set; }
    public bool IsActive { get; set; }
}
