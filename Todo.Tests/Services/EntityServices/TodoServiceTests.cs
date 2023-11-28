using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture;
using Bogus;
using Moq;
using Todo.Domain.Entities;
using Todo.Repository.Repositories.Interfaces;
using Todo.Services.EntityBuilder;
using Xunit;

namespace Todo.Tests.Services.EntityServices
{
    public class TodoServiceTests
    {
        private Fixture _fixture { get; set; }
        private readonly Mock<ITodoRepository> _mockRepository;
        public TodoServiceTests()
        {
            _fixture = new Fixture();
            _mockRepository = new Mock<ITodoRepository>();
        }

        [Fact]
        public async Task ShouldCallInsertWithTheCorrectTodo()
        {
            var todo = _fixture.Create<Domain.Entities.Todo>();
            var todoService = new TodoService(_mockRepository.Object);
            await todoService.CreateAsync(todo);

            _mockRepository.Verify(x => x.Insert(It.IsAny<Domain.Entities.Todo>()), Times.Once);
            _mockRepository.Verify(x => x.Insert(It.Is<Domain.Entities.Todo>(x => x == todo)));
        }

        [Fact]
        public async Task GetByIdAsyncReturnsTodoEntity()
        {
            // Arrange

            var expectedTodoEntity = _fixture.Create<Domain.Entities.Todo>();

            _mockRepository.Setup(x => x.GetSingleAsync(It.IsAny<Expression<Func<Domain.Entities.Todo, bool>>>()))
                .ReturnsAsync(expectedTodoEntity);

            var todoService = new TodoService(_mockRepository.Object);

            // Act
            var result = await todoService.GetByIdAsync(expectedTodoEntity.Id);

            // Assert
            _mockRepository.Verify(x => x.GetSingleAsync(It.IsAny<Expression<Func<Domain.Entities.Todo, bool>>>()), Times.Once);
            Assert.Equal(expectedTodoEntity, result);
        }

        [Fact]
        public async Task GetAllAsyncShouldReturnAllTodos()
        {
            // Arrange
            var todoEntities = new List<Domain.Entities.Todo> { new Domain.Entities.Todo(), new Domain.Entities.Todo() };
            _mockRepository.Setup(r => r.GetAllAsync(null)).ReturnsAsync(todoEntities);
            var todoService = new TodoService(_mockRepository.Object);
            // Act
            var result = await todoService.GetAllAsync();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetAllByUserIdAsyncShouldReturnTodosByUserId()
        {
            // Arrange
            var todoEntities = _fixture.CreateMany<Domain.Entities.Todo>(10);
            _mockRepository.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Domain.Entities.Todo, bool>>>()))
                .ReturnsAsync(todoEntities);
            var todoService = new TodoService(_mockRepository.Object);

            // Act
            var result = await todoService.GetAllByUserIdAsync(todoEntities.First().CreatedByUserId);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(todoEntities.Count(), result.Count());
            Assert.Equal(todoEntities.First().CreatedByUserId, result.First().CreatedByUserId);

        }

    }


    public interface ITodoRepository : IRepository<Domain.Entities.Todo>
    {
    }

    public interface ITodoService { }

    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task CreateAsync(Domain.Entities.Todo todo)
        {
            await _todoRepository.Insert(todo);
        }

        public async Task UpdateAsync(Domain.Entities.Todo todo)
        {
            await _todoRepository.Update(todo);
        }

        public async Task DeleteAsync(int id)
        {
            await _todoRepository.Delete(id);
        }

        public async Task<Domain.Entities.Todo> GetByIdAsync(int id)
        {
            var todoEntity = await _todoRepository.GetSingleAsync(x => x.Id == id);
            return todoEntity;
        }

        public async Task<IEnumerable<Domain.Entities.Todo>> GetAllAsync()
        {
            var todoEntities = await _todoRepository.GetAllAsync();
            return todoEntities;
        }

        public async Task<IEnumerable<Domain.Entities.Todo>> GetAllByUserIdAsync(int userId)
        {
            var todoEntities = await _todoRepository.GetAllAsync(x => x.CreatedByUserId == userId);
            return todoEntities;
        }
    }
}


