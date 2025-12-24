
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineFoodOrderingSystem.BLL.Profiles;
using OnlineFoodOrderingSystem.BLL.Services;
using OnlineFoodOrderingSystem.DAL.Data;
using OnlineFoodOrderingSystem.DAL.UnitOfWork;
using OnlineFoodOrderingSystem.Shared.BaseEntities;

namespace OnlineFoodOrderingSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                // 🔐 Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // 🔒 Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // 👤 User settings
                options.User.RequireUniqueEmail = true;

                // 🔑 Sign-in settings
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICheckoutService, CheckoutService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IFoodItemService, FoodItemService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IFoodBudgetService, FoodBudgetService>();

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            


            //builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
