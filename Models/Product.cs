namespace CSharpProductPractice.Models;

public class Product(int id, string name, int price, int stockQty)
{
    // set 전부 private -> 외부 접근 금지, 메서드 통해서만 가능 (캡슐화)
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public int Price { get; private set; } = price;
    public int StockQty { get; private set; } = stockQty;
    public bool IsActive { get; private set; } = true;

    public void Update(string name, int price, int stockQty)
    {
        Name = name;
        Price = price;
        StockQty = stockQty;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void ManageStock(int qty)
    {
        if (StockQty + qty < 0)
        {
            throw new InvalidOperationException("재고가 부족합니다.");
        }

        StockQty += qty;
        
    }
}