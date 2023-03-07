using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities.Concrete;
using MyBlog.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); //id alanının birer birer arttığını belirtir
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Content).IsRequired(true);
            builder.Property(x => x.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.Date).IsRequired(true);
            builder.Property(x => x.SeoAuthor).IsRequired(true);
            builder.Property(x => x.SeoAuthor).HasMaxLength(50);
            builder.Property(x => x.SeoDescription).IsRequired(true);
            builder.Property(x => x.SeoDescription).HasMaxLength(150);
            builder.Property(x => x.SeoAuthor).IsRequired(true);
            builder.Property(x => x.SeoAuthor).HasMaxLength(70);
            builder.Property(x => x.SeoTags).IsRequired(true);
            builder.Property(x => x.SeoTags).HasMaxLength(50);
            builder.Property(x => x.ViewsCount).IsRequired(true);
            builder.Property(x => x.CommentCount).IsRequired(true);
            builder.Property(x => x.Thumbnail).IsRequired(true);
            builder.Property(x => x.Thumbnail).HasMaxLength(250);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.ModifiedDate).IsRequired(true);
            builder.Property(x => x.IsActive).IsRequired(true);
            builder.Property(x => x.IsDeleted).IsRequired(true);
            builder.Property(x => x.Note).HasMaxLength(500);
            // Bir makale oluşurken bir kategoriye ve bir user a sahip olmalı.
            // Ve bir kullanıcı ve bir kategori birden fazla makaleye sahip olabilir
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);
            builder.ToTable("Articles"); // Tablo ismi
            //builder.HasData(new Article
            //{
            //    Id = 1,
            //    CategoryId = 1,
            //    Title = "C# 9.0 ve .NET 5 Yenilikleri",
            //    Content =
            //        "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir.  lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
            //    Thumbnail = "postImages/defaultThumbnail.jpg",
            //    SeoDescription = "C# 9.0 ve .NET 5 Yenilikleri",
            //    SeoTags = "C#, C# 9, .NET5, .NET Framework, .NET Core",
            //    SeoAuthor = "Alper Tunga",
            //    Date = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    ModifiedByName = "InitialCreate",
            //    ModifiedDate = DateTime.Now,
            //    Note = "C# 9.0 ve .NET 5 Yenilikleri",
            //    UserId = 1,
            //    ViewsCount = 100,
            //    CommentCount = 0
            //},
          //new Article
          //{
          //    Id = 2,
          //    CategoryId = 2,
          //    Title = "C++ 11 ve 19 Yenilikleri",
          //    Content =
          //        "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
          //    Thumbnail = "postImages/defaultThumbnail.jpg",
          //    SeoDescription = "C++ 11 ve 19 Yenilikleri",
          //    SeoTags = "C++ 11 ve 19 Yenilikleri",
          //    SeoAuthor = "Alper Tunga",
          //    Date = DateTime.Now,
          //    IsActive = true,
          //    IsDeleted = false,
          //    CreatedByName = "InitialCreate",
          //    CreatedDate = DateTime.Now,
          //    ModifiedByName = "InitialCreate",
          //    ModifiedDate = DateTime.Now,
          //    Note = "C++ 11 ve 19 Yenilikleri",
          //    UserId = 1,
          //    ViewsCount = 295,
          //    CommentCount = 0
          //},
          //new Article
          //{
          //    Id = 3,
          //    CategoryId = 3,
          //    Title = "JavaScript ES2019 ve ES2020 Yenilikleri",
          //    Content =
          //        "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
          //    Thumbnail = "postImages/defaultThumbnail.jpg",
          //    SeoDescription = "JavaScript ES2019 ve ES2020 Yenilikleri",
          //    SeoTags = "JavaScript ES2019 ve ES2020 Yenilikleri",
          //    SeoAuthor = "Alper Tunga",
          //    Date = DateTime.Now,
          //    IsActive = true,
          //    IsDeleted = false,
          //    CreatedByName = "InitialCreate",
          //    CreatedDate = DateTime.Now,
          //    ModifiedByName = "InitialCreate",
          //    ModifiedDate = DateTime.Now,
          //    Note = "JavaScript ES2019 ve ES2020 Yenilikleri",
          //    UserId = 1,
          //    ViewsCount = 12,
          //    CommentCount = 0
          //});
            //,
            //new Article
            //{
            //    Id = 4,
            //    CategoryId = 1,
            //    Title = "Typescript 4.1",
            //    Content =
            //    $"É um facto estabelecido de que um leitor é distraído pelo conteúdo legível de uma página quando analisa a sua mancha gráfica. Logo, o uso de Lorem Ipsum leva a uma distribuição mais ou menos normal de letras, ao contrário do uso de 'Conteúdo aqui,conteúdo aqui'', tornando-o texto legível. Muitas ferramentas de publicação electrónica e editores de páginas web usam actualmente o Lorem Ipsum como o modelo de texto usado por omissão, e uma pesquisa por 'lorem ipsum' irá encontrar muitos websites ainda na sua infância. Várias versões têm evoluído ao longo dos anos, por vezes por acidente, por vezes propositadamente (como no caso do humor).",
            //    Thumbnail = "postImages/defaultThumbnail.jpg",
            //    SeoDescription = "Typescript 4.1, Typescript, TYPESCRIPT 2021",
            //    SeoTags = "Typescript 4.1 Güncellemeleri",
            //    SeoAuthor = "Alper Tunga",
            //    Date = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    ModifiedByName = "InitialCreate",
            //    ModifiedDate = DateTime.Now,
            //    Note = "Typescript 4.1 Yenilikleri",
            //    UserId = 1,
            //    ViewsCount = 666,
            //    CommentCount = 0
            //});
        }
    }
}
