using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.Models
{
    public class DayClass
    {
        [Key]
        public int Id { get; set; }
        public int ClassNameId { get; set; }
        public ClassName ClassName { get; set; }
       
        public int DaysId { get; set; }
        public Days Days { get; set; }
        public virtual ICollection<TimeClassDayClass> TimeClassDayClasses { get; }

    }
}
