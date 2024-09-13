namespace OnlineShop.Products.Application.Dtos;

public record ProductUpdateDto(Guid Id, string Title, string Description, decimal Price);
