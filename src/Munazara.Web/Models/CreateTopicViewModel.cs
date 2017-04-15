using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Munazara.Web.Models
{
    public class CreateTopicViewModel
    {
        [Required]
        [DisplayName("Başlık")]
        [MaxLength(150,ErrorMessage ="Başlık en fazla 150 karakter olabilir")]
        public string Title { get; set; }


        [Required]
        [DisplayName("Kategori")]
        public int Category { get; set; }

        [Required]
      
        [DisplayName("İçerik")]
        public string Content { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        
    }
}