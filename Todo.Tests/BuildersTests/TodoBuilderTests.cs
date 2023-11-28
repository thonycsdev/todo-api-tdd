using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Bogus;
using Todo.Domain.Entities;
using Todo.Services.EntityBuilder;
using Xunit;

namespace Todo.Tests.BuildersTests
{
    public class TodoBuilderTests
    {
        private Fixture _fixture { get; set; }
        private Faker _faker { get; set; }
        private User _user { get; set; }
        public TodoBuilderTests()
        {
            _fixture = new Fixture();
            _faker = new Faker();
            _user = _fixture.Create<User>();
        }
        [Fact]
        public void ShouldCreateANewTodo()
        {
            var todo = TodoBuilder.New().WithUser(_user).Build();
            Assert.NotNull(todo);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldThrowAnErrorWhenTheNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => TodoBuilder.New().WithUser(_user).WithName(name).Build());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldThrowAnErrorWhenTheDescriptionIsNullOrEmpty(string description)
        {
            Assert.Throws<ArgumentNullException>(() => TodoBuilder.New().WithUser(_user).WithDescription(description).Build());
        }

        [Fact]
        public void ShouldCreateANewTodoWithName()
        {
            var fakeName = _faker.Name.JobTitle();
            var todo = TodoBuilder.New().WithUser(_user).WithName(fakeName).Build();
            Assert.Equal(fakeName, todo.Name);
        }

        [Fact]
        public void ShouldCreateANewTodoWithDescription()
        {
            var dakeDescription = _faker.Lorem.Sentence();
            var todo = TodoBuilder.New().WithUser(_user).WithDescription(dakeDescription).Build();
            Assert.Equal(dakeDescription, todo.Description);
        }

        [Fact]
        public void ShouldCreateANewTodoWithCompletedBeignAlwaysFalse()
        {
            var todo = TodoBuilder.New().WithUser(_user).Build();
            Assert.False(todo.IsCompleted);
        }

        [Fact]
        public void ShouldThrowAnErrorWhenCreatingATodoWithoutAUser()
        {
            Assert.Throws<ArgumentNullException>(() => TodoBuilder.New().WithUser(null).Build());

        }
    }
}