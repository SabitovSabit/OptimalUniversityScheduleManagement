using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClassRoom> ClassRooms { get; set; }
        public virtual ICollection<TimeDayClass> TimeDayClasses { get; set; }

    }
}
