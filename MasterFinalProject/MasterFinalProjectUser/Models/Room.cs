using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectUser.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
