using CSharpProductPractice.Models;

namespace CSharpProductPractice.Repositories;

public interface IProductRepository
{
    List<Product> FindAll();
    Product? FindById(int id);
    Product Create(string name, int price, int stockQty);
    void Delete(int id);
}