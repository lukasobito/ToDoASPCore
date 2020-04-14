using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoASPCore.ViewModel
{
    public class LoginUser
    {
        [Required]
        [Display(Name = "Adresse Email")]
        public string Email { get; set; }

        [Required]
        [DataType("password")]
        [Display(Name = "Mot de passe")]
        public string Pwd { get; set; }
    }
}
