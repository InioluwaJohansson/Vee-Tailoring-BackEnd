﻿using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface IClothCategoryRepo : IRepo <ClothCategory>
{
    Task<ClothCategory> GetById(int Id);
    Task<IList<ClothCategory>> List();
}
