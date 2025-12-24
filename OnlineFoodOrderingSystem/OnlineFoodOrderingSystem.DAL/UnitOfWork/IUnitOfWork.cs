using OnlineFoodOrderingSystem.DAL.Data;
using OnlineFoodOrderingSystem.DAL.Reposatories;
using OnlineFoodOrderingSystem.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.DAL.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<Cart> Carts { get; }
        IGenericRepository<CartItem> CartItems { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<OrderItem> OrderItems { get; }
        IGenericRepository<FoodItem> FoodItems { get; }
        IGenericRepository<Category> Categories { get; }
        Task<int> CompleteSaveAsync();
        Task ExecuteTransactionAsync(Func<Task> action);
    }
}
