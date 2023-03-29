using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface ICustomerRepo : IRepo<Customer>
{
    Task<Customer> GetById(int Id);
    Task<Customer> GetByUserId(int Id);
    Task<IList<Customer>> GetbyEmail(string email);
    Task<IList<Customer>> List();
}
