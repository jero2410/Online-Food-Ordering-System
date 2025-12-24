using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.BLL.Dtos.Order;
using OnlineFoodOrderingSystem.DAL.UnitOfWork;
using OnlineFoodOrderingSystem.Shared.Enum;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<UserOrderSummaryDto>> GetUserOrdersAsync(int userId)
    {
        var orders = await _uow.Orders.Query()
            .Include(o => o.OrderItems)
            .Where(o => o.CreatedBy == userId)
            .ToListAsync();

        return _mapper.Map<List<UserOrderSummaryDto>>(orders);
    }

    public async Task<OrderResponseDto> GetOrderDetailsAsync(int orderId)
    {
        var order = await _uow.Orders.Query()
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == orderId)
            ?? throw new Exception("Order not found");

        return _mapper.Map<OrderResponseDto>(order);
    }

    public async Task UpdateOrderStatusAsync(int orderId, OrderStatus status)
    {
        var order = await _uow.Orders.GetByIdAsync(orderId)
            ?? throw new Exception("Order not found");

        order.Status = status;
        order.UpdatedAt = DateTime.UtcNow;

        _uow.Orders.Update(order);
        await _uow.CompleteSaveAsync();
    }
}
