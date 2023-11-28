using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;
namespace Todo.Services.EntityBuilder
{
    public class TodoBuilder
    {
        private string Name { get; set; } = "Default Name";
        private string Description { get; set; } = "Default Description";
        private bool isCompleted { get; set; } = false;
        private User User { get; set; }
        public static TodoBuilder New()
        {
            return new TodoBuilder();
        }

        public Domain.Entities.Todo Build()
        {
            if (User is null)
                throw new ArgumentNullException("User cannot be null");
            return new Domain.Entities.Todo
            {
                Name = Name,
                Description = Description,
                IsCompleted = isCompleted,
                CreatedBy = User

            };
        }

        public TodoBuilder WithName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name cannot be null or empty");
            Name = name;
            return this;
        }

        public TodoBuilder WithDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException("DescriptionAttribute cannot be null or empty");
            Description = description;
            return this;
        }

        public TodoBuilder WithIsCompleted(bool isCompleted)
        {
            this.isCompleted = isCompleted;
            return this;
        }

        public TodoBuilder WithUser(User user)
        {
            User = user;
            return this;
        }


    }
}