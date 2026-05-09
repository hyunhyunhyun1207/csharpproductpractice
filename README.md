# Native C#
<br/>

## SpringBoot 대응점
```bash
Program.cs = Controller

ProductService = ServiceImpl

IProductService = Service 인터페이스

ProductRepository = Repository 구현체 또는 JPA Repository

IProductRepository = Repository 인터페이스

Product = Entity

ProductCreateRequest / ProductUpdateRequest / ProductResponse
= RequestDto / ResponseDto
```

## 프로젝트 구조


CSharpProductPractice
├─ Program.cs
├─ Models
│  └─ Product.cs
├─ DTOs
│  ├─ ProductCreateRequest.cs
│  ├─ ProductUpdateRequest.cs
│  └─ ProductResponse.cs
├─ Repositories
│  ├─ IProductRepository.cs
│  └─ ProductRepository.cs
└─ Services
   ├─ IProductService.cs
   └─ ProductService.cs
