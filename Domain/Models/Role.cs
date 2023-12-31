﻿using System;
using System.Collections.Generic;

namespace Domain.Models
// scaffolded from DB using EF

{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Role1 { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
