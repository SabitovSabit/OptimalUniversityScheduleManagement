﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MasterFinalProjectUser.Models
{

    public class AppUser : IdentityUser
    {
        [Required]
        public string Fullname { get; set; }
        public bool HasDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
