using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.BLL.Dtos.FoodItem;
using OnlineFoodOrderingSystem.BLL.Services;
using OnlineFoodOrderingSystem.DAL.UnitOfWork;
using OnlineFoodOrderingSystem.Shared.Models;

public class FoodItemService : IFoodItemService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public FoodItemService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<FoodItemResponseDto>> GetAllAsync()
    {
        var items = await _uow.FoodItems.Query()
            .Include(f => f.Category)
            .ToListAsync();

        return _mapper.Map<List<FoodItemResponseDto>>(items);
    }

    public async Task CreateAsync(CreateFoodItemDto dto, int userId)
    {
        var entity = _mapper.Map<FoodItem>(dto);
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreatedBy = userId;

        await _uow.FoodItems.AddAsync(entity);
        await _uow.CompleteSaveAsync();
    }

    public async Task UpdateAsync(int id, UpdateFoodItemDto dto, int userId)
    {
        var entity = await _uow.FoodItems.GetByIdAsync(id)
            ?? throw new Exception("Food item not found");

        _mapper.Map(dto, entity);
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = userId;

        _uow.FoodItems.Update(entity);
        await _uow.CompleteSaveAsync();
    }

    public async Task DeleteAsync(int id, int userId)
    {
        var entity = await _uow.FoodItems.GetByIdAsync(id)
            ?? throw new Exception("Food item not found");

        _uow.FoodItems.Delete(entity);
        await _uow.CompleteSaveAsync();
    }
}
