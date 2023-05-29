using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public virtual ICollection<Scheduler> Schedulers { get; set; }
        public int KafedraId { get; set; }
        public Kafedra Faculty { get; set; }
    }
}
