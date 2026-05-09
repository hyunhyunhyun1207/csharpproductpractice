using CSharpProductPractice.DTOs;
using CSharpProductPractice.Models;
using CSharpProductPractice.Repositories;
using CSharpProductPractice.Services;

IProductRepository productRepository = new ProductRepository();
IProductService productService = new ProductService(productRepository);

try
{
    ProductResponse product1 = productService.CreateProduct(
        new ProuductCreateRequest
        {
            Name = "노트북",
            Price = 1200000,
            StockQty = 10
        }
    );

    ProductResponse product2 = productService.CreateProduct(
        new ProuductCreateRequest
        {
            Name = "키보드",
            Price = 30000,
            StockQty = 50
        }
    );

    Console.WriteLine("=== 상품 등록 완료 ===");
    PrintProduct(product1);
    PrintProduct(product2);

    Console.WriteLine();
    Console.WriteLine("=== 전체 상품 목록 ===");

    List<ProductResponse> products = productService.GetProducts();

    foreach (ProductResponse product in products)
    {
        PrintProduct(product);
    }

    Console.WriteLine();
    Console.WriteLine("=== 상품 수정 ===");

    ProductResponse updatedProduct = productService.UpdateProduct(
        product1.Id,
        new ProductUpdateRequest
        {
            Name = "게이밍 노트북",
            Price = 1500000,
            StockQty = 7
        }
    );

    PrintProduct(updatedProduct);

    Console.WriteLine();
    Console.WriteLine("=== 상품 삭제 ===");

    productService.DeleteProduct(product2.Id);

    Console.WriteLine();
    Console.WriteLine("=== 삭제 후 상품 목록 ===");

    foreach (ProductResponse product in productService.GetProducts())
    {
        PrintProduct(product);
    }
}
catch (Exception e)
{
    Console.WriteLine($"오류 발생 : {e.Message}");
}

void PrintProduct(ProductResponse product)
{
    Console.WriteLine(
        $"ID: {product.Id}, 이름: {product.Name}, 가격: {product.Price}, 재고 : {product.StockQty}, 활성화 : {product.IsActive}"
    );
}