using CSharpProductPractice.DTOs;
using CSharpProductPractice.Models;

namespace CSharpProductPractice.Services;

public interface IProductService
{
    List<ProductResponse> GetProducts();
    ProductResponse GetProductById(int id);
    ProductResponse CreateProduct(ProductCreateRequest request);
    ProductResponse UpdateProduct(int id, ProductUpdateRequest request);
    void DeleteProduct(int id);

    ProductResponse ManageStock(int id, int qty);
}