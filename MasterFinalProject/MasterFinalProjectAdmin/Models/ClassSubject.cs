using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.Models
{
    public class ClassSubject
    {

        [Key]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int ClassNameId { get; set; }
        public ClassName ClassName { get; set; }
    }
}
