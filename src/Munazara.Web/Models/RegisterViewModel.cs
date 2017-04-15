using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Munazara.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        [MaxLength(20, ErrorMessage = "Kullanıcı adı en fazla 20 karakter olabilir")]
        [Remote("CheckUserName", "Account", HttpMethod = "POST", ErrorMessage = "Bu kullanıcı adıyla daha önce kayıt yapılmış")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("E-Posta")]
        [MaxLength(50, ErrorMessage = "E-Posta en fazla 50 karakter olabilir")]
        //[Remote("CheckEmail", "Account", HttpMethod = "POST", ErrorMessage = "Bu E-Posta adresiyle daha önce kayıt yapılmış")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Şifre Tekrar")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Şifre ve tekrarı uyuşmuyor")]
        public string PasswordRepeat { get; set; }
    }
}