using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.BLL.Dtos.Category;
using OnlineFoodOrderingSystem.BLL.Services;
using OnlineFoodOrderingSystem.DAL.UnitOfWork;
using OnlineFoodOrderingSystem.Shared.Models;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<CategoryResponseDto>> GetAllAsync()
    {
        var categories = await _uow.Categories.Query().ToListAsync();
        return _mapper.Map<List<CategoryResponseDto>>(categories);
    }

    public async Task CreateAsync(CreateCategoryDto dto, int userId)
    {
        var entity = _mapper.Map<Category>(dto);
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreatedBy = userId;

        await _uow.Categories.AddAsync(entity);
        await _uow.CompleteSaveAsync();
    }
}
