using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        [DisplayName("Mevcut Şifreniz")]
        [Required(ErrorMessage = "{0} Boş Olmamalıdır...")] //{0} -> display name de yazan değer
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DisplayName("Yeni Şifreniz")]
        [Required(ErrorMessage = "{0} Boş Olmamalıdır...")] //{0} -> display name de yazan değer
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DisplayName("Yani Şifrenizin Tekrarı")]
        [Required(ErrorMessage = "{0} Boş Olmamalıdır...")] //{0} -> display name de yazan değer
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage ="Girmiş Olduğunuz Yeni Şifreniz İle Yeni Şifrenizin Tekrarı Eşleşmelidir!")]
        public string RepeatPassword { get; set; }
    }
}
