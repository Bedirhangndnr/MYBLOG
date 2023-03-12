using MyBlog.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Dtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")]
        [MaxLength(100, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır")]
        public string Title { get; set; }
        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır")]
        public string Content { get; set; }
        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")]
        [MaxLength(250, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Küçük Olmamalıdır")]
        public string Thumbnail { get; set; }
        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:dd/MM/yyyy")]
        public DateTime Date { get; set; }
        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")]
        [MaxLength(50, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        public string SeoAuthor { get; set; }
        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")]
        [MaxLength(150, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        public string SeoDescription { get; set; }
        [DisplayName("Seo Etiketler")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")]
        [MaxLength(70, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        public string SeoTags { get; set; }
        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")]
        public bool IsActive { get; set; }

        [DisplayName("Silinsin Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilemez...")]
        public bool IsDeleted { get; set; }
        [Required]
        public int userId { get; set; }
    }
}
