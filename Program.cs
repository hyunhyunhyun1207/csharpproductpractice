using CSharpProductPractice.DTOs;
using CSharpProductPractice.Repositories;
using CSharpProductPractice.Services;
using System.Threading;


IProductRepository productRepository = new ProductRepository();
IProductService productService = new ProductService(productRepository);

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("===== 상품 관리 프로그램 =====");
    Console.WriteLine("[1] 상품 등록 [2] 상품 목록 조회 [3] 상품 단건 조회");
    Console.WriteLine("[4] 상품 수정 [5] 상품 삭제 [6] 재고 수량 변경");
    Console.WriteLine("[0] 종료");
    Console.Write("메뉴 선택: ");

    string? menu = Console.ReadLine();

    Console.WriteLine();

    try
    {
        switch (menu)
        {
            case "1":
                CreateProduct();
                Pause(1000);
                break;

            case "2":
                GetProducts();
                Pause(1000);
                break;

            case "3":
                GetProductById();
                Pause(1000);
                break;

            case "4":
                UpdateProduct();
                Pause(1000);
                break;

            case "5":
                DeleteProduct();
                Pause(1000);
                break;

            case "6" :
                ManageStock();
                Pause(1000);
                break;

            case "0":
                isRunning = false;
                Console.WriteLine("프로그램을 종료합니다.");
                break;

            default:
                Console.WriteLine("올바른 메뉴 번호를 입력하세요.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"오류 발생: {ex.Message}");
    }
}

void CreateProduct()
{
    Console.WriteLine("=== 상품 등록 ===");

    Console.Write("상품명: ");
    string name = ReadRequiredString();

    Console.Write("가격: ");
    int price = ReadInt();

    Console.Write("재고 수량: ");
    int stockQty = ReadInt();

    ProductCreateRequest request = new ProductCreateRequest
    {
        Name = name,
        Price = price,
        StockQty = stockQty
    };

    ProductResponse product = productService.CreateProduct(request);

    Console.WriteLine("상품이 등록되었습니다.");
    PrintProduct(product);
};

void GetProducts()
{
    Console.WriteLine("=== 상품 목록 조회 ===");

    List<ProductResponse> products = productService.GetProducts();

    if (products.Count == 0)
    {
        Console.WriteLine("등록된 상품이 없습니다.");
        return;
    }

    foreach (ProductResponse product in products)
    {
        PrintProduct(product);
    }
}

void GetProductById()
{
    Console.WriteLine("=== 상품 단건 조회 ===");

    Console.Write("상품 ID: ");
    int id = ReadInt();

    ProductResponse product = productService.GetProductById(id);

    PrintProduct(product);
}

void UpdateProduct()
{
    Console.WriteLine("=== 상품 수정 ===");

    Console.Write("수정할 상품 ID: ");
    int id = ReadInt();

    Console.Write("새 상품명: ");
    string name = ReadRequiredString();

    Console.Write("새 가격: ");
    int price = ReadInt();

    Console.Write("새 재고 수량: ");
    int stockQty = ReadInt();

    ProductUpdateRequest request = new ProductUpdateRequest
    {
        Name = name,
        Price = price,
        StockQty = stockQty
    };

    ProductResponse product = productService.UpdateProduct(id, request);

    Console.WriteLine("상품이 수정되었습니다.");
    PrintProduct(product);
}

void DeleteProduct()
{
    Console.WriteLine("=== 상품 삭제 ===");

    Console.Write("삭제할 상품 ID: ");
    int id = ReadInt();

    productService.DeleteProduct(id);

    Console.WriteLine("상품이 삭제되었습니다.");
}

void ManageStock()
{
    Console.WriteLine("=== 재고 관리 ===");

    Console.Write("변경할 상품 ID : ");
    int id = ReadInt();

    Console.Write("변경할 재고 : ");
    int qty = ReadInt();

    ProductResponse product = productService.ManageStock(id, qty);

    Console.WriteLine("재고가 변경되었습니다");
    Console.WriteLine($"선택한 상품 아이디 : {product.Id}, 선택한 변경 재고 수량 : {qty}");
    
    if (qty > 0)
    {   
        Console.WriteLine($"기존 재고 수량 : {product.StockQty+qty}, 변경 후 재고 수량 : {product.StockQty}");
    }
    else if (qty < 0)
    {
        Console.WriteLine($"기존 재고 수량 : {product.StockQty-qty}, 변경 후 재고 수량 : {product.StockQty}");
    }
    
}

int ReadInt()
{
    string? input = Console.ReadLine();

    bool isValidNumber = int.TryParse(input, out int number);

    if (!isValidNumber)
    {
        throw new ArgumentException("숫자를 입력해야 합니다.");
    }

    return number;
}

string ReadRequiredString()
{
    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        throw new ArgumentException("값을 입력해야 합니다.");
    }

    return input;
}


void PrintProduct(ProductResponse product)
{
    Console.WriteLine(
        $"ID: {product.Id}, 이름: {product.Name}, 가격: {product.Price}원, 재고: {product.StockQty}, 활성화: {product.IsActive}"
    );
}

void Pause(int milliseconds = 1000)
{
    Thread.Sleep(milliseconds);
}