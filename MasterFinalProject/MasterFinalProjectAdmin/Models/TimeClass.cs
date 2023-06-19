using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.Models
{
    public class TimeClass
    {
        [Key]
        public int Id { get; set; }
        public int ClassNameId { get; set; }
        public ClassName ClassName { get; set; }
        public int TimeOfDayId { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public virtual ICollection<TimeClassDayClass> TimeClassDayClasses { get;}
        
    }
}
