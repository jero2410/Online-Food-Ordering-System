using OnlineFoodOrderingSystem.BLL.Dtos.FoodItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.BLL.Services
{
    public interface IFoodBudgetService
    {
        Task<List<BudgetFoodResponseDto>> GetFoodsWithinBudget(decimal budget);
    }
}
