﻿using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface IArmTypeRepo: IRepo<ArmType>
{
    Task<ArmType> GetById(int Id);
    Task<IList<ArmType>> List();
}
