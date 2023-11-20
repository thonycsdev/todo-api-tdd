using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities
{
    public class Todo
    {
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsDone { get; set; }
        public User CreatedBy { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
