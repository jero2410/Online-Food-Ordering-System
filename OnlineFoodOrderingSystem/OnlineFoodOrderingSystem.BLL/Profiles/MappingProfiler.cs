using AutoMapper;
using OnlineFoodOrderingSystem.BLL.Dtos.CardItem;
using OnlineFoodOrderingSystem.BLL.Dtos.Cart;
using OnlineFoodOrderingSystem.BLL.Dtos.Category;
using OnlineFoodOrderingSystem.BLL.Dtos.FoodItem;
using OnlineFoodOrderingSystem.BLL.Dtos.Order;
using OnlineFoodOrderingSystem.BLL.Dtos.OrderItems;
using OnlineFoodOrderingSystem.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.BLL.Profiles
{
    public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // =========================
        // CATEGORY
        // =========================
        CreateMap<Category, CategoryResponseDto>();

        CreateMap<CreateCategoryDto, Category>()
            .ReverseMap();


        // =========================
        // FOOD ITEM
        // =========================
        CreateMap<FoodItem, FoodItemResponseDto>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<CreateFoodItemDto, FoodItem>()
            .ReverseMap();

        CreateMap<UpdateFoodItemDto, FoodItem>()
            .ReverseMap();


        // =========================
        // CART ITEM
        // =========================
        CreateMap<CartItem, CartItemResponseDto>()
            .ForMember(dest => dest.CartItemId,
                       opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FoodItemName,
                       opt => opt.MapFrom(src => src.FoodItem.Name))
            .ForMember(dest => dest.TotalPrice,
                       opt => opt.MapFrom(src => src.UnitPrice * src.Quantity));


        // =========================
        // CART
        // =========================
        CreateMap<Cart, CartResponseDto>()
            .ForMember(dest => dest.CartId,
                       opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Items,
                       opt => opt.MapFrom(src => src.CartItems))
            .ForMember(dest => dest.Total,
                       opt => opt.MapFrom(src =>
                           src.CartItems.Sum(i => i.UnitPrice * i.Quantity)));


        // =========================
        // ORDER ITEM
        // =========================
        CreateMap<OrderItem, OrderItemResponseDto>()
            .ForMember(dest => dest.FoodItemId,
                       opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.FoodItemName,
                       o => o.Ignore());


            // =========================
            // ORDER
            // =========================
            CreateMap<Order, OrderResponseDto>()
            .ForMember(dest => dest.OrderId,
                       opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Status,
                       opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Items,
                       opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.TotalAmount,
                       opt => opt.MapFrom(src =>
                           src.OrderItems.Sum(i => i.Price)));

        CreateMap<Order, UserOrderSummaryDto>()
            .ForMember(dest => dest.OrderId,
                       opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Status,
                       opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.TotalAmount,
                       opt => opt.MapFrom(src =>
                           src.OrderItems.Sum(i => i.Price)));
    }
}
}
