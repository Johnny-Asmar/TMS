using System;
using System.Collections.Generic;

namespace Domain.Models
// scaffolded from DB using EF

{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
