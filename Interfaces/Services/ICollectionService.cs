using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Interfaces.Services;

public interface ICollectionService
{
    Task<BaseResponse> Create(CreateCollectionDto createCollectionDto);
    Task<BaseResponse> Update(int id, UpdateCollectionDto updateCollectionDto);
    Task<CollectionResponseModel> GetById(int id);
    Task<BaseResponse> BuyCollection(int id,int customerId);
    Task<CollectionsResponseModel> GetByCollectionName(string CollectionId);
    Task<CollectionsResponseModel> GetCollectionsByClothCategory(int CollectionId);
    Task<CollectionsResponseModel> GetCollectionsByClothCategoryClothGender(int clothCategory, int clothGender);
    Task<CollectionsResponseModel> GetAllCollections();
    Task<DashBoardResponse> CollectionsDashboard();
    Task<BaseResponse> DeActivateCollection(int id);
}
