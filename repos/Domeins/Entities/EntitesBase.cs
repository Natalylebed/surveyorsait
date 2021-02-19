using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repos.Domeins.Entities
{
    
    public abstract class EntitesBase
    { 
        protected EntitesBase() => DateAdded = DateTime.UtcNow;

    [Required]
        public Guid Id { get; set; }

        [Display(Name ="Название (заголовок)")]
        public virtual string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }
        
        [Display(Name = " Содержание страницы")]
        public virtual string Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }
        
        [Display(Name = "SEO метатег Title")]
        public  string MetаTitle { get; set; }
       
        [Display(Name = "SEO метатег Description")]
        public  string MetaDiscription { get; set; }
       
        [Display(Name = "Seo метатег Keywords")]
        public  string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }

    }
}
