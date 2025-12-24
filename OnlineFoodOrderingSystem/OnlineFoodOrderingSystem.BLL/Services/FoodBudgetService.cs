using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.BLL.Dtos.FoodItem;
using OnlineFoodOrderingSystem.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.BLL.Services
{
    public class FoodBudgetService : IFoodBudgetService
    {
        private readonly IUnitOfWork _uow;

        public FoodBudgetService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<BudgetFoodResponseDto>> GetFoodsWithinBudget(decimal budget)
        {
            if (budget <= 0)
                throw new Exception("Budget must be greater than zero");

            var foods = await _uow.FoodItems
                .Query()
                .Include(f => f.Category)
                .Where(f =>
                    f.Price <= budget &&
                    !f.IsDeleted &&
                    f.IsAvailable
                )
                .OrderBy(f => f.Price)
                .ToListAsync();

            return foods.Select(f => new BudgetFoodResponseDto
            {
                FoodItemId = f.Id,
                Name = f.Name,
                Price = f.Price,
                CategoryName = f.Category.Name
            }).ToList();
        }
    }
}
