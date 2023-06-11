using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Security.AccessControl;
using System.IO;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Services;

public class CollectionService : ICollectionService
{
    ICollectionRepo _repository;
    ITemplateRepo _templaterepository;
    ICustomerRepo _customerrepository;
    IOrderRepo _orderRepository;
    public CollectionService(ICustomerRepo customerrepository, IOrderRepo orderRepository, ICollectionRepo repository, ITemplateRepo templateRepo)
    {
        _repository = repository;
        _templaterepository = templateRepo;
        _customerrepository = customerrepository;
        _orderRepository = orderRepository;
    }
    public async Task<BaseResponse> Create(CreateCollectionDto createCollectionDto)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Collection");
        if (Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if(createCollectionDto.ImageUrl != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(createCollectionDto.ImageUrl.FileName);
            var filePath = Path.Combine(folderPath, createCollectionDto.ImageUrl.FileName);
            var extention = Path.GetExtension(createCollectionDto.ImageUrl.FileName);
            if(!System.IO.Directory.Exists(filePath))
            {
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createCollectionDto.ImageUrl.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        var Collection = new Collection()
        {
            CollectionId = $"COLLECTION{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()}",
            CollectionName = createCollectionDto.CollectionName,
            CollectionDescription = createCollectionDto.CollectionDescription,
            ClothCategoryId = createCollectionDto.ClothCategoryId,
            ClothGenderId = createCollectionDto.ClothGenderId,
            ImageUrl = imagePath,
            IsDeleted = false,
        };
        await _repository.Create(Collection);
        return new BaseResponse()
        {
            Message = "Collection Created Successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> Update(int id, UpdateCollectionDto updateCollectionDto)
    {
        var Collection = await _repository.GetById(id);
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Collection");
        if (Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var imagePath = "";
        if (updateCollectionDto.ImageUrl != null)
        {
            var fileName = Path.GetFileNameWithoutExtension(updateCollectionDto.ImageUrl.FileName);
            var filePath = Path.Combine(folderPath, updateCollectionDto.ImageUrl.FileName);
            var extention = Path.GetExtension(updateCollectionDto.ImageUrl.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateCollectionDto.ImageUrl.CopyToAsync(stream);
                }
                imagePath = fileName;
            }
        }
        if (Collection != null)
        {
            Collection.CollectionName = updateCollectionDto.CollectionName ?? Collection.CollectionName;
            Collection.CollectionDescription = updateCollectionDto.CollectionDescription ?? Collection.CollectionDescription;
            Collection.ClothCategoryId = updateCollectionDto.ClothCategoryId;
            Collection.ClothGenderId = updateCollectionDto.ClothCategoryId;
            Collection.ImageUrl = imagePath ?? Collection.ImageUrl;
            await _repository.Update(Collection);
            return new BaseResponse()
            {
                Message = "Collection Updated Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Update Collection Successfully",
            Status = false
        };
    }
    public async Task<CollectionResponseModel> GetById(int id)
    {
        var Collection = await _repository.GetById(id);
        var Template = await _templaterepository.GetAllTemplatesByCollectionId(Collection.Id);
        if (Collection != null && Template != null)
        {
            return new CollectionResponseModel()
            {
                Data = await GetDetails(Collection, Template),
                Message = "Collection Retrieved Successfully",
                Status = true
            };
        }
        
        return new CollectionResponseModel()
        {
            Data = null,
            Message = "No Items In This Collection Yet!",
            Status = false
        };
    }
    public async Task<BaseResponse> BuyCollection(int id, int customerId)
    {
        var Collection = await _repository.GetById(id);
        var Template = await _templaterepository.GetAllTemplatesByCollectionId(Collection.Id);
        var customer = await _customerrepository.GetByUserId(customerId);
        if (Collection != null && Template != null)
        {
            foreach (var template in Template)
            {
                var order = new Order()
                {
                    OrderId = $"ORDER{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15).ToUpper()}",
                    ArmTypeId = template.ArmTypeId,
                    ClothCategoryId = template.ClothCategoryId,
                    ClothGenderId = template.ClothGenderId,
                    ColorId = template.ColorId,
                    StyleId = template.StyleId,
                    PatternId = template.PatternId,
                    MaterialId = template.MaterialId,
                    Pieces = Collection.Pieces,
                    OrderPerson = OrderPerson.MySelf,
                    CustomerId = customer.Id,
                    AddToCart = false,
                    IsDeleted = false,
                    LastModifiedOn = DateTime.UtcNow,
                    OrderAddress = new OrderAddress()
                    {
                        PostalCode = customer.UserDetails.Address.PostalCode,
                        Street = customer.UserDetails.Address.Street,
                        City = customer.UserDetails.Address.City,
                        Region = customer.UserDetails.Address.Region,
                        State = customer.UserDetails.Address.State,
                        Country = customer.UserDetails.Address.Country,
                        IsDeleted = false,
                    },
                    OrderMeasurements = new OrderMeasurement()
                    {
                        AnkleSize = customer.Measurements.AnkleSize,
                        ArmLength = customer.Measurements.ArmLength,
                        ArmSize = customer.Measurements.ArmSize,
                        BackWaist = customer.Measurements.BackWaist,
                        BodyHeight = customer.Measurements.BodyHeight,
                        BurstGirth = customer.Measurements.BurstGirth,
                        FrontWaist = customer.Measurements.FrontWaist,
                        Head = customer.Measurements.Head,
                        HighHips = customer.Measurements.HighHips,
                        HipSize = customer.Measurements.HipSize,
                        LegLength = customer.Measurements.LegLength,
                        NeckSize = customer.Measurements.NeckSize,
                        ShoulderWidth = customer.Measurements.ShoulderWidth,
                        ThirdQuarterLegLength = customer.Measurements.ThirdQuarterLegLength,
                        WaistSize = customer.Measurements.WaistSize,
                        WristCircumfrence = customer.Measurements.WristCircumfrence,
                        IsDeleted = false,
                    }
                };
                await _orderRepository.Create(order);
            }
            return new BaseResponse()
            {
                Message = "Collection Items Added To Order List Successfully",
                Status = true
            };
        }

        return new BaseResponse()
        {
            Message = "Unable To Add Collection Items!",
            Status = false
        };
    }
    public async Task<CollectionsResponseModel> GetByCollectionName(string CollectionName)
    {
        var Collections = await _repository.GetByCollectionName(CollectionName);
        if (Collections != null)
        {
            List<GetCollectionDto> CollectionList = new List<GetCollectionDto>();
            foreach (var Collection in Collections)
            {
                var template = await _templaterepository.GetAllTemplatesByCollectionId(Collection.Id);
                CollectionList.Add(await GetDetails(Collection, template));
            }
            return new CollectionsResponseModel()
            {
                Data = CollectionList,
                Message = "Collections List Retrieved Successfully",
                Status = true
            };
        }

        return new CollectionsResponseModel()
        {
            Data = null,
            Message = "No Items In This Collection Yet!",
            Status = false
        };
    }
    public async Task<CollectionsResponseModel> GetCollectionsByClothCategory(int clothCategoryId)
    {
        var Collections = await _repository.GetAllCollectionsByClothCategory(clothCategoryId);
        if (Collections != null)
        {
            List<GetCollectionDto> CollectionList = new List<GetCollectionDto>();
            foreach (var Collection in Collections)
            {
                var template = await _templaterepository.GetAllTemplatesByCollectionId(Collection.Id);
                CollectionList.Add(await GetDetails(Collection, template));
            }
            return new CollectionsResponseModel()
            {
                Data = CollectionList,
                Message = "Collections List Retrieved Successfully",
                Status = true
            };
        }
        return new CollectionsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Collections List Successfully",
            Status = false
        };
    }
    public async Task<CollectionsResponseModel> GetCollectionsByClothCategoryClothGender(int clothCategoryId, int clothGenderId)
    {
        var Collections = await _repository.GetAllCollectionsByClothCategoryClothGender(clothCategoryId, clothGenderId);
        if (Collections != null)
        {
            List<GetCollectionDto> CollectionList = new List<GetCollectionDto>();
            foreach (var Collection in Collections)
            {
                var template = await _templaterepository.GetAllTemplatesByCollectionId(Collection.Id);
                CollectionList.Add(await GetDetails(Collection, template));
            }
            return new CollectionsResponseModel()
            {
                Data = CollectionList,
                Message = "Collections List Retrieved Successfully",
                Status = true
            };
        }
        return new CollectionsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Collections List Successfully",
            Status = false
        };
    }
    public async Task<CollectionsResponseModel> GetAllCollections()
    {
        var Collections = await _repository.GetAllCollections();
        if (Collections != null)
        {
            List<GetCollectionDto> CollectionList = new List<GetCollectionDto>();
            foreach (var Collection in Collections)
            {
                var template = await _templaterepository.GetAllTemplatesByCollectionId(Collection.Id);
                CollectionList.Add(await GetDetails(Collection, template));
            }
            return new CollectionsResponseModel()
            {
                Data = CollectionList,
                Message = "Collections List Retrieved Successfully",
                Status = true
            };
        }
        return new CollectionsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Collections List Successfully",
            Status = false
        };
    }
    public async Task<GetCollectionDto> GetDetails(Collection Collection, IList<Template> templates)
    {
        List<GetTemplateDto> TemplateList = new List<GetTemplateDto>();
        foreach (var template in templates)
        {
            TemplateList.Add(GetTemplateDetails(template));
        }
        return new GetCollectionDto()
        {
            Id = Collection.Id,
            CollectionName = Collection.CollectionName,
            CollectionDescription = Collection.CollectionDescription,
            ClothCategory = Collection.ClothCategory.ClothName,
            ClothGender = Collection.ClothGender.Gender,
            ImageUrl = Collection.ImageUrl,
            TemplateDto = TemplateList
        };
    }
    public GetTemplateDto GetTemplateDetails(Template template)
    {
        return new GetTemplateDto()
        {
            Id = template.Id,
            TemplateId = template.TemplateId,
            TemplateName = template.TemplateName,
            GetStyleDto = new GetStyleDto()
            {
                StyleId = template.Style.StyleId,
                StyleName = template.Style.StyleName,
                StyleUrl = template.Style.StyleUrl,
                StylePrice = template.Style.StylePrice,
                GetClothCategoryDto = new GetClothCategoryDto()
                {
                    Id = template.ClothCategory.Id,
                    ClothName = template.ClothCategory.ClothName
                },
                GetClothGenderDto = new GetClothGenderDto()
                {
                    Id = template.ClothGender.Id,
                    Gender = template.ClothGender.Gender,
                }
            },
            GetPatternDto = new GetPatternDto()
            {
                Id = template.Pattern.Id,
                PatternName = template.Pattern.PatternName,
                PatternUrl = template.Pattern.PatternUrl,
                PatternPrice = template.Pattern.PatternPrice,
                GetClothCategoryDto = new GetClothCategoryDto()
                {
                    Id = template.ClothCategory.Id,
                    ClothName = template.ClothCategory.ClothName
                },
                GetClothGenderDto = new GetClothGenderDto()
                {
                    Id = template.ClothGender.Id,
                    Gender = template.ClothGender.Gender,
                }
            },
            GetMaterialDto = new GetMaterialDto()
            {
                Id = template.Material.Id,
                MaterialName = template.Material.MaterialName,
                MaterialUrl = template.Material.MaterialUrl,
                MaterialPrice = template.Material.MaterialPrice,
            },
            GetColorDto = new GetColorDto()
            {
                Id = template.Color.Id,
                ColorName = template.Color.ColorName,
                ColorCode = template.Color.ColorCode,
            },
            GetArmTypeDto = new GetArmTypeDto()
            {
                Id = template.ArmType.Id,
                ArmLength = template.ArmType.ArmLength
            },
            Price = template.Style.StylePrice + template.Pattern.PatternPrice + template.Material.MaterialPrice,
        };
    }
    public async Task<DashBoardResponse> CollectionsDashboard()
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
            Message = "No Available Collections!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivateCollection(int id)
    {
        var Collection = await _repository.GetById(id);
        if (Collection != null)
        {
            Collection.IsDeleted = true;
            await _repository.Update(Collection);
            return new BaseResponse()
            {
                Message = "Collection Deleted Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Delete Collection Successfully",
            Status = true
        };
    }
}
