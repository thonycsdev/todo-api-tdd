using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Bogus;
using Todo.Domain.Entities;
using Todo.Repository.Repositories.Interfaces;
using Todo.Services.EntityBuilder;
using Xunit;

namespace Todo.Tests.Services.EntityServices
{
    public class TodoServiceTests
    {
        private Fixture _fixture { get; set; }
        private Faker _faker { get; set; }
        private User _user { get; set; }
        public TodoServiceTests()
        {
            _fixture = new Fixture();
            _faker = new Faker();
            _user = _fixture.Create<User>();
        }

    }


    public interface ITodoRepository : IRepository<Domain.Entities.Todo>
    {
    }
}


