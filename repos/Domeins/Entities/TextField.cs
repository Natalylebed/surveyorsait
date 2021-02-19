using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repos.Domeins.Entities
{ 
    public class TextField:EntitesBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "информационная страница";

        [Display(Name = " Содержание страницы")]
        public override string Text { get; set; } = "Содержание заполняется администратором";

    }
}
