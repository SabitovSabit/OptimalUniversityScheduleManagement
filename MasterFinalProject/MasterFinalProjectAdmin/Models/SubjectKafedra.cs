using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectAdmin.Models
{
    public class SubjectKafedra
    {
        [Key]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int KafedraId { get; set; }
        public Kafedra Kafedra { get; set; }
    }
}
