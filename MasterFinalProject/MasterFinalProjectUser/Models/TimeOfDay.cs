using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectUser.Models
{
    public class TimeOfDay
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public virtual ICollection<TimeDayClass> TimeDayClasses { get; set; }



    }
}
