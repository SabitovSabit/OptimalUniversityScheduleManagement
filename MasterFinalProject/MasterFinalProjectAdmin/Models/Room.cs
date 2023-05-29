using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
