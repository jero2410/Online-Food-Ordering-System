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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<Cart> Carts { get; }
        public IGenericRepository<CartItem> CartItems { get; }
        public IGenericRepository<Order> Orders { get; }
        public IGenericRepository<OrderItem> OrderItems { get; }
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<FoodItem> FoodItems { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Carts = new GenericRepository<Cart>(_context);
            CartItems = new GenericRepository<CartItem>(_context);
            Orders = new GenericRepository<Order>(_context);
            OrderItems = new GenericRepository<OrderItem>(_context);
            Categories = new GenericRepository<Category>(_context);
            FoodItems = new GenericRepository<FoodItem>(_context);
        }

        public async Task<int> CompleteSaveAsync() => await _context.SaveChangesAsync();

        public async Task ExecuteTransactionAsync(Func<Task> action)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await action();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
