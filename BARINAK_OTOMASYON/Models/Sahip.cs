using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BARINAK_OTOMASYON.Models
{
    public class Sahip
    {
        [Key]
        public int SAHIP_ID { get; set; }
        [Display(Name = "Sahip Adi")]
        [Required(ErrorMessage = "Sahiplenenin Adını Girmek Zorunludur!!")]
        public string SAHIP_AD { get; set; }
        [Display(Name = "Sahip SoyAdi")]
        [Required(ErrorMessage = "Sahiplenenin Soyadını Girmek Zorunludur!!")]
        public string SAHIP_SOYAD { get; set; }
        [Display(Name = "Sahip Telefonu")]
        [Required(ErrorMessage = "Sahiplenenin Telefonunu Girmek Zorunludur!!")]
        public string SAHIP_TEL { get; set; }
        [Display(Name = "Sahip Adres")]
        [Required(ErrorMessage = "Sahiplenenin Adresini Girmek Zorunludur!!")]
        public string SAHIP_ADRES { get; set; }
    }
}