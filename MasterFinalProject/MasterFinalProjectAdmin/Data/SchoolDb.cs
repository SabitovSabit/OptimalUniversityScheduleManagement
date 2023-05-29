using MasterFinalProjectAdmin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Data
{
    public class SchoolDb:DbContext
    {
        public SchoolDb(DbContextOptions<SchoolDb> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassName> ClassNames { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Scheduler> Schedulers { get; set; }
        public DbSet<Kafedra> Kafedras { get; set;}
        public DbSet<Faculty> Faculty { get; set;}
        public DbSet<Room> Rooms { get; set; }
    }
}
