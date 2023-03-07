using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Dtos
{
    public class UserAddDto
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} Boş Olmamalıdır...")] //{0} -> display name de yazan değer
        [MaxLength(50, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır")]
        public string UserName { get; set; }
        [DisplayName("E-Posta Adresi")]
        [Required(ErrorMessage = "{0} Boş Olmamalıdır...")] //{0} -> display name de yazan değer
        [MaxLength(100, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(10, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} Boş Olmamalıdır...")] //{0} -> display name de yazan değer
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} Boş Olmamalıdır...")] //{0} -> display name de yazan değer
        [MaxLength(13, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")] // +90 555 555 55 55 // 13 karakter
        [MinLength(13, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır")]
        [DataType(DataType.Password)]
        public string PhoneNumber { get; set; }
        [DisplayName("Resim")]
        [Required(ErrorMessage = "Lütfen, bir {0} seçiniz.")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }
        public string Picture { get; set; } = ""; // bu kısmın bir değere eşitlenmemesi gerekir. Şu an bunı yapmadığım taktirde addUser
                                                  // operationında modelstate bunu required olarak varsaydığı ve bunu halledemediğim
                                                  // için geçici olarak bu şekilde tuttum
    }
}
