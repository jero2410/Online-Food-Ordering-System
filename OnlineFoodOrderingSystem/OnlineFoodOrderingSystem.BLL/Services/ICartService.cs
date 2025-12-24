using OnlineFoodOrderingSystem.BLL.Dtos;
using OnlineFoodOrderingSystem.BLL.Dtos.CardItem;
using OnlineFoodOrderingSystem.BLL.Dtos.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.BLL.Services
{
    public interface ICartService
    {
        Task<CartResponseDto> GetCartAsync(int userId);
        Task AddItemAsync(int userId, int cartId, int foodItemId, int quantity);
        Task UpdateItemAsync(int cartItemId, int quantity, int userId);
        Task RemoveItemAsync(int cartItemId, int userId);
        Task ClearCartAsync(int cartId, int userId);
    }
}
