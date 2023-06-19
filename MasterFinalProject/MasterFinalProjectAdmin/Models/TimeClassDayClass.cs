using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.Models
{
    public class TimeClassDayClass
    {
        [Key]
        public int Id { get; set; }
        public int TimeClassId { get; set; }
        public TimeClass TimeClass { get; set; }
        public int DayClassId { get; set; }
        public DayClass DayClass { get; set; }
        
    }
}
