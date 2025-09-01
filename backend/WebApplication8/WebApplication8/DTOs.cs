namespace WebApplication8.Dtos;

public record AddItemRequest(int ProductId, int Quantity);
public record UpdateQuantityRequest(int Quantity);

public record CartItemDto(int Id, int ProductId, string ProductName,
                          int Quantity, decimal UnitPrice, decimal LineTotal);

public record CartDto(int Id, string UserId, decimal Total, IEnumerable<CartItemDto> Items);
