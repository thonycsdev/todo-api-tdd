using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Repository.Repositories.Interfaces;

namespace Todo.Repository.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TodoContext _context;
        private DbSet<T> _entity;
        public Repository(TodoContext todoContext)
        {
            _context = todoContext;
            _entity = _context.Set<T>();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null)
        {
            if (expression is null)
                return await _entity.ToListAsync();
            return await _entity.Where(expression).ToListAsync();
        }

        public T GetSingle(Expression<Func<T, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(T entity)
        {
            await _entity.AddAsync(entity);
            entity.CreatedAt = DateTime.Now;
            await SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
