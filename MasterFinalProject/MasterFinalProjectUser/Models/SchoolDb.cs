using MasterFinalProjectUser.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MasterFinalProjectUser.Data
{
    public class SchoolDb:IdentityDbContext<AppUser>
    {
        public SchoolDb(DbContextOptions<SchoolDb> options) : base(options)
        {

        }
     
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassName> ClassNames { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Kafedra> Kafedras { get; set;}
        public DbSet<Faculty> Faculty { get; set;}
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TimeOfDay> TimeOfDays{ get; set; }
        public DbSet<Days> Days{ get; set; }
        public DbSet<TimeDayClass> TimeDayClasses   { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Teacher>()
            .HasOne<Kafedra>(a => a.Kafedra)
            .WithMany(s=>s.Teachers)
            .HasForeignKey(a=>a.KafedraId);

        }
    }
}
