using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
namespace Vee_Tailoring.Implementations.Services;

public class CategoryService : ICategoryService
{
    ICategoryRepo _repository;
    public CategoryService(ICategoryRepo repository)
    {
        _repository = repository;
    }
    public async Task<BaseResponse> Create(CreateCategoryDto createCategoryDto)
    {
        var clothCategory = new Category()
        {
            CategoryName = createCategoryDto.CategoryName,
            CategoryDescription = createCategoryDto.CategoryDescription,
            IsDeleted = false
        };
        await _repository.Create(clothCategory);
        return new BaseResponse()
        {
            Message = "Category Created Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse> Update(int id, UpdateCategoryDto updateCategoryDto)
    {
        var updatedCategory = await _repository.GetById(id);
        if (updatedCategory != null)
        {
            updatedCategory.CategoryName = updateCategoryDto.CategoryName ?? updatedCategory.CategoryName;
            await _repository.Update(updatedCategory);
            return new BaseResponse()
            {
                Message = "Category Updated Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Update Category Successfully",
                Status = false
            };
        }
    }

    public async Task<CategoryResponseModel> GetById(int id)
    {
        var clothCategory = await _repository.GetById(id);
        if (clothCategory != null)
        {
            return new CategoryResponseModel()
            {
                Data = GetDetails(clothCategory),
                Message = "Category Retrieved Successfully",
                Status = true
            };
        }
        return new CategoryResponseModel()
        {
            Data = null,
            Message = "Unable To Retieve Category Successfully",
            Status = false
        };
    }

    public async Task<CategorysResponseModel> GetAllCategory()
    {
        var clothCategories = await _repository.List();
        if (clothCategories != null)
        {
            return new CategorysResponseModel()
            {
                Data = clothCategories.Select(clothCategory => GetDetails(clothCategory)).ToList(),
                Message = "Category List Retrieved Successfully",
                Status = true
            };
        }
        return new CategorysResponseModel()
        {
            Data = null,
            Message = "Unble To Retrieve Category List Successfully",
            Status = true
        };
    }
    public GetCategoryDto GetDetails(Category Category)
    {
        return new GetCategoryDto
        {
            Id = Category.Id,
            CategoryName = Category.CategoryName,
            CategoryDescription = Category.CategoryDescription,
        };
    }

    public async Task<DashBoardResponse> CategoryDashboard()
    {
        int total = (await _repository.GetAll()).Count;
        int active = (await _repository.GetByExpression(x => x.IsDeleted == false)).Count;
        int inActive = (await _repository.GetByExpression(x => x.IsDeleted == true)).Count;
        if (total != 0)
        {
            return new DashBoardResponse
            {
                Total = total,
                Active = active,
                InActive = inActive,
                Status = true,
            };
        }return new DashBoardResponse
        {
            Message = "No Available Categories!",
            Status = false,
        };
    }

    public async Task<BaseResponse> DeActivateCategory(int id)
    {
        var updatedCategory = await _repository.GetById(id);
        if (updatedCategory != null)
        {
            updatedCategory.IsDeleted = true;
            await _repository.Update(updatedCategory);
            return new BaseResponse()
            {
                Message = "Category Deleted Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Delete Category Successfully",
                Status = false
            };
        }
    }
}
