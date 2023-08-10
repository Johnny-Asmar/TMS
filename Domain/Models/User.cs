using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string username { get; set; } = null!;
        public string password { get; set; } = null!;

        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
