namespace CSharpProductPractice.DTOs;

public class ProductCreateRequest
{
    public string Name { get; set; } = "";
    public int Price { get; set; }
    public int StockQty { get; set; }
}
