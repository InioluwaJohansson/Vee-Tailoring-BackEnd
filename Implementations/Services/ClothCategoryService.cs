using V_Tailoring.Entities;
using V_Tailoring.Interfaces.Respositories;
using V_Tailoring.Interface.Services;
using V_Tailoring.Models.DTOs;
namespace V_Tailoring.Implementations.Services
{
    public class ClothCategoryService : IClothCategoryService
    {
        IClothCategoryRepo _repository;
        public ClothCategoryService(IClothCategoryRepo repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse> Create(CreateClothCategoryDto createClothCategoryDto)
        {
            var clothCategory = new ClothCategory()
            {
                ClothName = createClothCategoryDto.ClothName,
                IsDeleted = false
            };
            await _repository.Create(clothCategory);
            return new BaseResponse()
            {
                Message = "Cloth Category Created Successfully",
                Status = true
            };
        }
        public async Task<BaseResponse> Update(int id, UpdateClothCategoryDto updateClothCategoryDto)
        {
            var ClothCategory = await _repository.GetById(id);
            if (ClothCategory != null)
            {
                ClothCategory.ClothName = updateClothCategoryDto.ClothName ?? ClothCategory.ClothName;
                await _repository.Update(ClothCategory);
                return new BaseResponse()
                {
                    Message = "Cloth Category Updated Successfully",
                    Status = true
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Unable To Update Cloth Category",
                    Status = false
                };
            }
        }
        public async Task<ClothCategoryResponseModel> GetById(int id)
        {
            var clothCategory = await _repository.GetById(id);
            if (clothCategory != null)
            {
                return new ClothCategoryResponseModel()
                {
                    Data = GetDetails(clothCategory),
                    Message = "Cloth Category Retrieved Successfully",
                    Status = true
                };
            }
            return new ClothCategoryResponseModel()
            {
                Data = null,
                Message = "Unable To Retrieve Cloth Category",
                Status = false
            };
        }
        public async Task<ClothCategorysResponseModel> GetAllClothCategory()
        {
            var clothCategories = await _repository.List();
            if (clothCategories != null)
            {
                return new ClothCategorysResponseModel()
                {
                    Data = clothCategories.Select(clothCategory => GetDetails(clothCategory)).ToList(),
                    Message = "Cloth Category List Retrieved Successfully",
                    Status = true
                };
            }
            return new ClothCategorysResponseModel()
            {
                Data = null,
                Message = "Unable To Retrieve Cloth Category List",
                Status = false
            };
        }
        public async Task<DashBoardResponse> ClothCategoryDashboard()
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
            }
            return new DashBoardResponse
            {
                Message = "No Available Cloth Categories!",
                Status = false,
            };
        }
        public GetClothCategoryDto GetDetails(ClothCategory clothCategory)
        {
            return new GetClothCategoryDto
            {
                Id = clothCategory.Id,
                ClothName = clothCategory.ClothName,
            };
        }
        public async Task<BaseResponse> DeActivateClothCategory(int id)
        {
            var response = await _repository.GetById(id);
            if (response != null)
            {
                response.IsDeleted = true;
                await _repository.Update(response);
                return new BaseResponse()
                {
                    Message = "Cloth Category Deleted Successfully",
                    Status = true
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Unable To Delete Cloth Category",
                    Status = false
                };
            }
        }
    }
}