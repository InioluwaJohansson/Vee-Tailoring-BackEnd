﻿using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Entities;

namespace Vee_Tailoring.Interfaces.Respositories;

public interface IPaymentRepo : IRepo<Payment>
{
    Task<IList<Payment>> GenerateInvoice(int id); 
}
