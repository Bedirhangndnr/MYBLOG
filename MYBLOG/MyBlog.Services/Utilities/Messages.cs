﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Utilities
{
    public static class Messages
    {
        public static class General
        {
            public static string UnKnownError()
            {
                return "Bilinmeyen bir hata ile karşılaşıldı";
            }
        }
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) { return "Hiçbir kategori bulunamadı"; }
                else { return "Böyle bir kategori bulunamadı"; }
            }
            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} Adlı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} Adlı kategori başarıyla silinmiştir.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} Adlı kategori kalıcı olarak başarıyla silinimiştir.";
            }
        }
        public static class Article
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Makaleler Bulunamadı";
                else { return "Böyle bir makale bulunamadı"; }
            }
            public static string Add(string articleName)
            {
                return $"{articleName} adlı makale başarıyla silinmiştir.";
            }
            public static string Update(string articleName)
            {
                return $"{articleName} Adlı makale başarıyla güncellenmiştir.";
            }
            public static string Delete(string articleName)
            {
                return $"{articleName} Adlı makale başarıyla silinmiştir.";
            }
            public static string HardDelete(string articleName)
            {
                return $"{articleName} Adlı makale kalıcı olarak başarıyla silinimiştir.";
            }
        }
    }
}