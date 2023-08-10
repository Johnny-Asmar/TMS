using System;
using System.Collections.Generic;

namespace Domain.Models
// scaffolded from DB using EF

{
    public partial class Task
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedTo { get; set; }
        public DateTime endDate { get; set; }
        public string status { get; set; }


        public virtual User AssignedToNavigation { get; set; } = null!;
        public virtual Priority PriorityNavigation { get; set; } = null!;
    }
}
