using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranserMateAsssment.Core.Common.Infrastructure.TableModels;

namespace TransfermateAssesment.Infrastructure.DatabaseContext
{
     public partial class TaskContext :DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options):base(options)
        {

        }
        public virtual DbSet<TaskMaster> Tasks { get; set; }
        public virtual DbSet<UserMaster> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskMaster>(entity =>
            {
                entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(50);
                entity.HasOne(e => e.User)
                .WithMany(p => p.Tasks)
                .HasForeignKey(e => e.UserId);
            });
            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
               
            });
            OnModelCreatingPartial(modelBuilder);  
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
