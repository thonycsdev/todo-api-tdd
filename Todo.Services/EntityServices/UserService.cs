using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Repository.Repositories.Interfaces;
using Todo.Services.Interfaces;

namespace Todo.Services.EntityServices
{
    public class UserService : IService<User>
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var result = await _userRepository.GetAllAsync();
            return result;
        }

        public Task<User> GetSingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> InsertAsync(User entity)
        {
            await _userRepository.Insert(entity);
            return entity;
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
