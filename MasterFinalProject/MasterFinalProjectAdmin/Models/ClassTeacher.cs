using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.Models
{
    public class ClassTeacher
    {
        [Key]
        public int Id { get; set; }
        public int ClassNameId { get;set; } 
        public ClassName ClassName { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
