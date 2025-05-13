namespace BackendAspNet.modules.order.dto;

public class CreateOrderDto
{
    public string UserId { get; set; } = string.Empty;

    public List<CreateOrderItemDto> Items { get; set; } = new();
}

public class CreateOrderItemDto
{
    public string ProductId { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
}