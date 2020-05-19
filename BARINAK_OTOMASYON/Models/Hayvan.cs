using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BARINAK_OTOMASYON.Models
{
    public class Hayvan
    {
        [Key]
        public int HAYVAN_ID { get; set; }
        [Display(Name = "Hayvan Cinsi")]
        [Required(ErrorMessage = "Hayvan Cinsi Girmek Zorunludur!!")]
        public string HAYVAN_CINSI { get; set; }
        [Display(Name = "Hayvan Yasi")]
        [Required(ErrorMessage = "Hayvanın Yaşını Girmek Zorunludur!!")]
        public string HAYVAN_YASI { get; set; }
        [Display(Name = "Hayvan Cinsiyeti")]
        [Required(ErrorMessage = "Hayvanın Cinsiyetini Girmek Zorunludur!!")]
        public string HAYVAN_CINSIYETI { get; set; }
    }
}