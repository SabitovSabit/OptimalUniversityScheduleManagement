using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterFinalProjectAdmin.Models
{
    public class TimeDayClass
    {
        [Key]
        public int Id { get; set; }
        public int ClassNameId { get; set; }
        public ClassName ClassName { get; set; }
        public int TimeOfDayId { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public int DaysId { get; set; }
        public Days Days { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}
