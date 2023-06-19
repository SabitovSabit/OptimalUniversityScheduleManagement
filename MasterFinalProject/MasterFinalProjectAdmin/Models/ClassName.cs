using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Models
{
    public class ClassName
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int KafedraId { get; set; }
        public Kafedra? Kafedra { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public virtual ICollection<ClassTeacher> ClassTeachers{ get; set; }
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
        public virtual ICollection<TimeDayClass> TimeDayClasses { get; set; }
        public virtual ICollection<TimeClass> TimeClasses { get; set; }
        public virtual ICollection<DayClass> DayClasses { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }







    }
}
