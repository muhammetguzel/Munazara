using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Munazara.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        [MaxLength(20, ErrorMessage = "Kullanıcı adı en fazla 20 karakter olabilir")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}