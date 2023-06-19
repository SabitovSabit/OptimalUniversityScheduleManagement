using MasterFinalProjectAdmin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Data
{
    public class SchoolDb : IdentityDbContext<AppUser>
    {
        public SchoolDb(DbContextOptions<SchoolDb> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<ClassName> ClassNames { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Kafedra> Kafedras { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Days> Days { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<DayClass> DayClasses { get; set; }
        public DbSet<TimeClass> TimeClasses { get; set; }
        public DbSet<TimeOfDay> TimeOfDays { get; set; }
        public DbSet<TimeDayClass> TimeDayClasses { get; set; }
        public DbSet<TimeClassDayClass> TimeClassDayClasses { get; set; }
        public DbSet<SubjectKafedra> SubjectKafedras { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>()
            .HasOne<Kafedra>(a => a.Kafedra)
            .WithMany(s => s.Teachers)
            .HasForeignKey(a => a.KafedraId);

            modelBuilder.Entity<ClassTeacher>()
                .HasOne(ct => ct.Teacher)
                .WithMany()
                .HasForeignKey(ct => ct.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassTeacher>()
                .HasOne(ct => ct.ClassName)
                .WithMany()
                .HasForeignKey(ct => ct.ClassNameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimeClassDayClass>()
               .HasOne(ct => ct.TimeClass)
               .WithMany()
               .HasForeignKey(ct => ct.TimeClassId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimeClassDayClass>()
               .HasOne(ct => ct.DayClass)
               .WithMany()
               .HasForeignKey(ct => ct.DayClassId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DayClass>()
               .HasOne(ct => ct.Days)
               .WithMany()
               .HasForeignKey(ct => ct.DaysId)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DayClass>()
               .HasOne(ct => ct.ClassName)
               .WithMany()
               .HasForeignKey(ct => ct.ClassNameId)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeClass>()
              .HasOne(ct => ct.TimeOfDay)
              .WithMany()
              .HasForeignKey(ct => ct.TimeOfDayId)
              .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeClass>()
              .HasOne(ct => ct.ClassName)
              .WithMany()
              .HasForeignKey(ct => ct.ClassNameId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimeDayClass>()
              .HasOne(ct => ct.Teacher)
              .WithMany()
              .HasForeignKey(ct => ct.TeacherId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimeDayClass>()
               .HasOne(ct => ct.Room)
               .WithMany()
               .HasForeignKey(ct => ct.RoomId)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeDayClass>()
            .HasOne(ct => ct.Subject)
            .WithMany()
            .HasForeignKey(ct => ct.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeDayClass>()
               .Property(e => e.RoomId)
               .HasColumnName("RoomId");
            modelBuilder.Entity<TimeDayClass>()
              .Property(e => e.TeacherId)
              .HasColumnName("TeacherId");
            modelBuilder.Entity<TimeDayClass>()
             .Property(e => e.SubjectId)
            .HasColumnName("SubjectId");


        }
    }
}
