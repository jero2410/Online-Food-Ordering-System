using OnlineFoodOrderingSystem.BLL.Services;
using OnlineFoodOrderingSystem.DAL.UnitOfWork;
using OnlineFoodOrderingSystem.Shared.Enum;
using OnlineFoodOrderingSystem.Shared.Models;

public class CheckoutService : ICheckoutService
{
    private readonly IUnitOfWork _uow;

    public CheckoutService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<int> CheckoutAsync(int cartId, int userId)
    {
        var cart = await _uow.Carts.GetByIdAsync(cartId)
            ?? throw new Exception("Cart not found");

        if (!cart.CartItems.Any())
            throw new Exception("Cart is empty");

        var order = new Order
        {
            Status = OrderStatus.Preparing,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = userId
        };

        await _uow.Orders.AddAsync(order);

        foreach (var item in cart.CartItems)
        {
            await _uow.OrderItems.AddAsync(new OrderItem
            {
                Order = order,
                ProductId = item.FoodItemId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Price = item.UnitPrice * item.Quantity,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userId
            });

            _uow.CartItems.Delete(item);
        }

        order.Status = OrderStatus.Preparing;

        await _uow.CompleteSaveAsync();
        return order.Id;
    }
}
