﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
   
        public int ClassNameId { get; set; }
        public ClassName ClassName { get; set; }
    }
}
