using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.Models
{
    public class ClassRoom
    {
        [Key]
        public int Id { get; set; }
        public int ClassNameId { get; set; }
        public ClassName ClassName { get; set; }
        public int RoomId { get; set; }
        public Room Room{ get; set; }
    }
}
