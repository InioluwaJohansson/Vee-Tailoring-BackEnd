using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Implementations.Services;

public class MaterialService : IMaterialService
{
    IMaterialRepo _repository;
    public MaterialService(IMaterialRepo repository)
    {
        _repository = repository;
    }
    public async Task<BaseResponse> Create(CreateMaterialDto createMaterialDto)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Material\\");
        if (!System.IO.Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if (createMaterialDto.MaterialUrl != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(createMaterialDto.MaterialUrl.FileName);
            var filePath = Path.Combine(folderPath, createMaterialDto.MaterialUrl.FileName);
            var extension = Path.GetExtension(createMaterialDto.MaterialUrl.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createMaterialDto.MaterialUrl.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        var clothMaterial = new Material()
        {
            MaterialName = createMaterialDto.MaterialName,
            MaterialUrl = imagePath,
            MaterialPrice = createMaterialDto.MaterialPrice,
            IsDeleted = false
        };
        await _repository.Create(clothMaterial);
        return new BaseResponse()
        {
            Message = "Material Created Successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> Update(int id, UpdateMaterialDto updateMaterialDto)
    {
        var updatedMaterial = await _repository.GetById(id);
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Material\\");
        if (!System.IO.Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if (updateMaterialDto.MaterialUrl != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(updateMaterialDto.MaterialUrl.FileName);
            var filePath = Path.Combine(folderPath, updateMaterialDto.MaterialUrl.FileName);
            var extension = Path.GetExtension(updateMaterialDto.MaterialUrl.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateMaterialDto.MaterialUrl.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        if (updatedMaterial != null)
        {
            updatedMaterial.MaterialName = updateMaterialDto.MaterialName ?? updatedMaterial.MaterialName;
            updatedMaterial.MaterialUrl = imagePath ?? updatedMaterial.MaterialUrl;
            updatedMaterial.MaterialPrice = updateMaterialDto.MaterialPrice;
            await _repository.Update(updatedMaterial);
            return new BaseResponse()
            {
                Message = "Material Updated Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Update Material Successfully",
                Status = false
            };
        }
    }
    public async Task<MaterialResponseModel> GetById(int id)
    {
        var Material = await _repository.GetById(id);
        if (Material != null)
        {
            return new MaterialResponseModel()
            {
                Data = GetDetails(Material),
                Message = "Material Retrieved Successfully",
                Status = true
            };
        }
        return new MaterialResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Material Successfully",
            Status = false
        };
    }
    public async Task<MaterialsResponseModel> GetByMaterialName(string materialName)
    {
        var Material = await _repository.GetByMaterialName(materialName);
        if (Material != null)
        {
            return new MaterialsResponseModel()
            {
                Data = Material.Select(material => GetDetails(material)).ToList(),
                Message = "Material Retrieved Successfully",
                Status = true
            };
        }
        return new MaterialsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Material Successfully",
            Status = false
        };
    }
    public async Task<MaterialsResponseModel> GetByMaterialPrice(decimal price)
    {
        var materials = await _repository.ListByMaterialPrice(price);
        if (materials != null)
        {
            return new MaterialsResponseModel()
            {
                Data = materials.Select(material => GetDetails(material)).ToList(),
                Message = "Materials List Retrieved Successfully",
                Status = true
            };
        }
        return new MaterialsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Materials List Successfully",
            Status = false
        };
    }
    public async Task<MaterialsResponseModel> GetAllMaterial()
    {
        var materials = await _repository.List();
        if (materials != null)
        {
            return new MaterialsResponseModel()
            {
                Data = materials.Select(material => GetDetails(material)).ToList(),
                Message = "Materials List Retrieved Successfully",
                Status = true
            };
        }
        return new MaterialsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Materials List Successfully",
            Status = false
        };
    }
    public GetMaterialDto GetDetails(Material material)
    {
        return new GetMaterialDto
        {
            MaterialName = material.MaterialName,
            MaterialUrl =  material.MaterialUrl,
            MaterialPrice = material.MaterialPrice,
        };
    }
    public async Task<DashBoardResponse> MaterialsDashboard()
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
            Message = "No Available Materials!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivateMaterial(int id)
    {
        var updatedMaterial = await _repository.GetById(id);
        if (updatedMaterial != null)
        {
            updatedMaterial.IsDeleted = true;
            await _repository.Update(updatedMaterial);
            return new BaseResponse()
            {
                Message = "Material Deleted Successfully",
                Status = true
            };
        }
        else
        {
            return new BaseResponse()
            {
                Message = "Unable To Delete Material Successfully",
                Status = false
            };
        }
    }
}
