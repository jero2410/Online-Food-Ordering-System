using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.BLL.Dtos.Cart;
using OnlineFoodOrderingSystem.BLL.Services;
using OnlineFoodOrderingSystem.DAL.UnitOfWork;
using OnlineFoodOrderingSystem.Shared.Models;

public class CartService : ICartService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CartService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<CartResponseDto> GetCartAsync(int userId)
    {
        var cart = await _uow.Carts.Query()
            .Include(c => c.CartItems)
                .ThenInclude(ci => ci.FoodItem)
            .FirstOrDefaultAsync(c => c.CreatedBy == userId);

        if (cart == null)
            throw new Exception("Cart not found");

        return _mapper.Map<CartResponseDto>(cart);
    }

    public async Task AddItemAsync(int userId, int cartId, int foodItemId, int quantity)
    {
        var cart = await _uow.Carts.GetByIdAsync(cartId)
            ?? throw new Exception("Cart not found");

        var item = cart.CartItems
            .FirstOrDefault(x => x.FoodItemId == foodItemId);

        if (item != null)
        {
            item.Quantity += quantity;
            item.UpdatedBy = userId;
            item.UpdatedAt = DateTime.UtcNow;
            _uow.CartItems.Update(item);
        }
        else
        {
            await _uow.CartItems.AddAsync(new CartItem
            {
                CartId = cartId,
                FoodItemId = foodItemId,
                Quantity = quantity,
                UnitPrice = (await _uow.FoodItems.GetByIdAsync(foodItemId))!.Price,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userId
            });
        }

        await _uow.CompleteSaveAsync();
    }

    public async Task UpdateItemAsync(int cartItemId, int quantity, int userId)
    {
        var item = await _uow.CartItems.GetByIdAsync(cartItemId)
            ?? throw new Exception("Cart item not found");

        item.Quantity = quantity;
        item.UpdatedBy = userId;
        item.UpdatedAt = DateTime.UtcNow;

        _uow.CartItems.Update(item);
        await _uow.CompleteSaveAsync();
    }

    public async Task RemoveItemAsync(int cartItemId, int userId)
    {
        var item = await _uow.CartItems.GetByIdAsync(cartItemId)
            ?? throw new Exception("Cart item not found");

        item.DeletedAt = DateTime.UtcNow;
        item.UpdatedBy = userId;

        _uow.CartItems.Delete(item);
        await _uow.CompleteSaveAsync();
    }

    public async Task ClearCartAsync(int cartId, int userId)
    {
        var cart = await _uow.Carts.GetByIdAsync(cartId)
            ?? throw new Exception("Cart not found");

        foreach (var item in cart.CartItems)
            _uow.CartItems.Delete(item);

        await _uow.CompleteSaveAsync();
    }
}
