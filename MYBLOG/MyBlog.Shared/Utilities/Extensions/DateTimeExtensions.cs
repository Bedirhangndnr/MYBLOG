using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Shared.Utilities.Extensions
{
    //extend işlemleri ile ilgili sınıf ve metodlarımız her zaman stati olmalıdır
    public static class DateTimeExtensions
    {
        public static string FullDateAndTimeStringWithUnderScore(this DateTime dateTime)
        {
            //return "a";
            return $"{dateTime.Millisecond}_{dateTime.Second}_{dateTime.Minute}_{dateTime.Hour}_{dateTime.Day}_{dateTime.Month}_{dateTime.Year}";
            // Örnek Çıktı -> BedirhanGündöner_558_4_33_12_3_7_2023_.png
        }
    }
}
