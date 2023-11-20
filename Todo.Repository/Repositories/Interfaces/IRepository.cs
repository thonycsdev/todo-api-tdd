using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null);
        Task<T> GetSingleAsync(Expression<Func<T, bool>>? expression = null);
        T GetSingle(Expression<Func<T, bool>>? expression = null);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
