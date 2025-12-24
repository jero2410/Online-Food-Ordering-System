using OnlineFoodOrderingSystem.BLL.Dtos.FoodItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.BLL.Services
{
    public interface IFoodItemService
    {
        Task<List<FoodItemResponseDto>> GetAllAsync();
        Task CreateAsync(CreateFoodItemDto dto, int userId);
        Task UpdateAsync(int id, UpdateFoodItemDto dto, int userId);
        Task DeleteAsync(int id, int userId);
    }
}
