using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.Models
{
    public class Days
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
        public virtual ICollection<TimeDayClass> TimeDayClasses { get; set; }
        public virtual ICollection<DayClass> DayClasses { get; set; }


    }
}
