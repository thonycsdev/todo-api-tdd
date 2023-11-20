using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Repository.Repositories.Generic;
using Todo.Repository.Repositories.Interfaces;

namespace Todo.Repository.Repositories.EntitiesRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TodoContext todoContext) : base(todoContext)
        {
        }
    }
}
