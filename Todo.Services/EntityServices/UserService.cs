using Services.Utils;
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
        public async Task DeleteAsync(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var result = await _userRepository.GetAllAsync();
            return result;
        }

        public async Task<User> GetSingleAsync(int id)
        {
                var result = await _userRepository.GetSingleAsync(x => x.Id == id);
                if(result is null)
                    throw new IndexOutOfRangeException();
                return result;

        }

        public async Task<User> InsertAsync(User entity)
        {
            entity.Password = entity.Password.CryptPassword();
            await _userRepository.Insert(entity);
            return entity;
        }

        public Task UpdateAsync(User entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
