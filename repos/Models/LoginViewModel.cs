using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using repos.Models;

namespace repos.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Логин")]

        public string UserName { get; set; }
        [Required]
        [UIHint("password")]
        [Display(Name ="Пароль")]
        public string Password { get; set; }

        [Display(Name ="Запомни меня?")]
        public bool RememberMe { get; set; }
    }
}
