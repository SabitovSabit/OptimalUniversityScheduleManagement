using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectUser.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
       
        public int KafedraId { get; set; }
        public Kafedra? Kafedra { get; set; }
    }
}
