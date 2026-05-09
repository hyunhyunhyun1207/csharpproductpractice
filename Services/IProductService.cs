using CSharpProductPractice.DTOs;

namespace CSharpProductPractice.Services;

public interface IProductService
{
    List<ProductResponse> GetProducts();
    ProductResponse GetProductById(int id);
    ProductResponse CreateProduct(ProuductCreateRequest request);
    ProductResponse UpdateProduct(int id, ProductUpdateRequest request);
    void DeleteProduct(int id);
}