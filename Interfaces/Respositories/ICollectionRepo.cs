using V_Tailoring.Entities;

namespace V_Tailoring.Interfaces.Respositories
{
    public interface ICollectionRepo : IRepo<Collection>
    {
        Task<Collection> GetById(int Id);
        Task<IList<Collection>> GetAllCollectionsByClothCategory(int clothCategory);
        Task<IList<Collection>> GetAllCollectionsByClothCategoryClothGender(int clothCategory, int clothGender);
        Task<IList<Collection>> GetAllCollections();
        Task<IList<Collection>> GetByCollectionName(string CollectionName);
    }
}
