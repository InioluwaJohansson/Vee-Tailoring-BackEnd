using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vee_Tailoring.Contracts;

namespace Vee_Tailoring.Interfaces.Respositories;

public interface IRepo<T> 
{
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Get(Expression<Func<T, bool>> expression);
    Task<IList<T>> GetAll();
    Task <bool>Delete(T entity);
    Task<IList<T>> GetByExpression(Expression<Func<T, bool>> expression);
}
