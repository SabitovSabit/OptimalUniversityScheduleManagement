using MasterFinalProjectAdmin.Models;
using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.VModel
{
    public class StudentVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string RoleTeacher { get; set; }
        public int ClassNameId { get; set; }
        public ClassName ClassName { get; set; }
    }
}
