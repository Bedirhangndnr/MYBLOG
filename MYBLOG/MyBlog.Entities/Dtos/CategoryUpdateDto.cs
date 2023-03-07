using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="{0} Boş Olmamalıdır...")] //{0} -> display name de yazan değer
        [MaxLength(70, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(3, ErrorMessage ="{0} {1} Karakterden Az Olmamalıdır")]
        public string Name{ get; set; }
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")] 
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır")]
        public string Description{ get; set; }
        [DisplayName("Kategori Not Alanı")]
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır")]
        public string Note{ get; set; }        
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage ="{0} Boş Olmamalıdır...")] 
        public bool IsActive{ get; set; }
        [DisplayName("Silindi Mi?")]
        [Required(ErrorMessage = "{0} Boş Olmamalıdır...")]
        public bool IsDeleted { get; set; }
    }
}
