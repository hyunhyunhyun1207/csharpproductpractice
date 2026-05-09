namespace CSharpProductPractice.DTOs;

public class ProuductCreateRequest
{
    public string Name { get; set; } = "";
    public int Price { get; set; }
    public int StockQty { get; set; }
}
