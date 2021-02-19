using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repos.Domeins.Entities
{
    public class ServiceItem : EntitesBase
    {
        public string CodeWord { get; set; }

        [Required(ErrorMessage = "заполните название услуги")]
        [Display(Name = "Название (заголовок)")]
        public override string Title { get; set; } 

        [Display(Name = "Краткое описание услуги")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание услуги")]
        public override string Text { get; set; }
    }
} 
