using OnlineFoodOrderingSystem.BLL.Dtos.Order;
using OnlineFoodOrderingSystem.Shared.Enum;

public interface IOrderService
{
    Task<List<UserOrderSummaryDto>> GetUserOrdersAsync(int userId);
    Task<OrderResponseDto> GetOrderDetailsAsync(int orderId);
    Task UpdateOrderStatusAsync(int orderId, OrderStatus status);
}
