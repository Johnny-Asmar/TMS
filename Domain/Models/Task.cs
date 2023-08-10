using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int AssignedTo { get; set; }

        public virtual User AssignedToNavigation { get; set; } = null!;
        public virtual Priority PriorityNavigation { get; set; } = null!;
    }
}
