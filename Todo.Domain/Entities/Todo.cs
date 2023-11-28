using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities
{
    public class Todo : BaseEntity
    {
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public User CreatedBy { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
