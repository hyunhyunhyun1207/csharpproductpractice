using CSharpProductPractice.Models;

namespace CSharpProductPractice.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> products = new();
    private int sequence = 1;

    public List<Product> FindAll()
    {
        return products;
    }

    public Product? FindById(int id)
    {
        return products.FirstOrDefault(product => product.Id == id);
    }

    public Product Save(Product product)
    {
        products.Add(product);
        return product;
    }

    public Product Create(string name, int price, int stockQty)
    {
        Product product = new Product(sequence++, name, price, stockQty);
        products.Add(product);

        return product;
    }

    public void Delete(int id)
    {
        Product? product = FindById(id);

        if (product != null)
        {
            products.Remove(product);
        }
    }
}