using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DomainModel.EntityFramework
{
    public class LabManDBContext:DbContext
    {
        private readonly DbSet<Student> Students;
        private readonly DbSet<Group> Groups;
        private readonly DbSet<Grade> Grades;
        public LabManDBContext(DbContextOptions options) : base(options)
        {
      
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Group>().HasKey(g => g.Id);
            modelBuilder.Entity<Grade>().HasKey(g => g.Id);

            modelBuilder.Entity<Student>()
                .HasOne<Group>(s => s.Group)
                .WithMany(g => g.Students).IsRequired()
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Student>()
                .HasMany<Grade>();
                
        }
       
    }
}
