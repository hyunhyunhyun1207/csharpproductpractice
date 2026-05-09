using CSharpProductPractice.DTOs;
using CSharpProductPractice.Models;
using CSharpProductPractice.Repositories;

namespace CSharpProductPractice.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public List<ProductResponse> GetProducts()
    {
        return productRepository
            .FindAll()
            .Where(product => product.IsActive)
            .Select(ToResponse)
            .ToList();
    }
    // GetProduct() 간소화 시 아래 주석 코드
    // .ToList() -> [..
    //                ]
    // public List<ProductResponse> GetProduct()
    // {
    //     return [.. productRepository
    //         .FindAll()
    //         .Where(product => product.IsActive)
    //         .Select(ToResponse)];
    // }

    public ProductResponse GetProductById(int id)
    {
        Product product = GetProductOrThrow(id);

        return ToResponse(product);
    }

    public ProductResponse CreateProduct(ProuductCreateRequest request)
    {
        ValidateProductRequest(request.Name, request.Price, request.StockQty);

        Product product = productRepository.Create(
            request.Name,
            request.Price,
            request.StockQty
        );

        return ToResponse(product);
    }

    public ProductResponse UpdateProduct(int id, ProductUpdateRequest request)
    {
        ValidateProductRequest(request.Name, request.Price, request.StockQty);

        Product product = GetProductOrThrow(id);

        product.Update(request.Name, request.Price, request.StockQty);

        return ToResponse(product);
    }


    // 소프트 삭제 -> 데이터 이력 필요
    public void DeleteProduct(int id)
    {
        Product product = GetProductOrThrow(id);

        product.Deactivate();
    }

    private Product GetProductOrThrow(int id)
    {
        Product? product = productRepository.FindById(id);

        if (product == null || !product.IsActive)
        {
            throw new InvalidOperationException("상품을 찾을 수 없습니다.");
        }

        return product;
    }

    // 서비스 검증 항목
    // 상품명이 비었거나 가격, 수량이 이상하면 예외처리
    private void ValidateProductRequest(string name, int price, int stockQty)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("상품명은 필수입니다.");
        }

        if (price <= 0)
        {
            throw new ArgumentException("상품 가격은 0보다 커야 합니다.");
        }

        if (stockQty < 0)
        {
            throw new ArgumentException("재고 수량은 0 이상이어야 합니다");
        }
    }

    // 엔티티를 직접 반환하지 않기 위한 메서드
    private ProductResponse ToResponse(Product product)
    {
        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            StockQty = product.StockQty,
            IsActive = product.IsActive
        };
    }

}