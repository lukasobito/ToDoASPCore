using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoASPCore.ViewModel
{
    public class SignInUser
    {
        [Required]
        [Display(Name = "Adresse Email")]
        public string Email { get; set; }

        [Required]
        [DataType("password")]
        [Display(Name = "Mot de passe")]
        public string Pwd { get; set; }

        [Required]
        [Compare(nameof(Pwd), ErrorMessage = "Les mots de passe saisis ne correspondent pas")]
        [DataType(DataType.Password)]
        [Display(Name = "Répétez le mot de passe")]
        public string PwdRepeat { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nom de famille")]
        public string LastName { get; set; }


    }
}
