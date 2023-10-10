using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Persistence.DB
// scaffolded from DB using EF

{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Domain.Models.Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        private IConfiguration _configuration { get; set; }

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetSection("ConnectionStrings").GetSection("DevDatabase").Value);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Id, "roles_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Role1).HasColumnName("Role");
            });

            modelBuilder.Entity<Domain.Models.Task>(entity =>
            {
                entity.HasIndex(e => e.Id, "tasks_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.AssignedTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tasks_users_Id_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id, "users_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoleId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
