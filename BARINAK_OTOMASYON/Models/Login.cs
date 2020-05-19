using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BARINAK_OTOMASYON.Models
{
    public class Login
    {
        [Key]
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}