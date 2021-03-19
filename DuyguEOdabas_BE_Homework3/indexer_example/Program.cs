using System;
using System.Collections.Generic;

namespace indexer_example
{
    class Program
    {
        static void Main(string[] args)
        {
            //indexer kullanmadan tanımlama
            //var lessonArray = new List<string>();
            //lessonArray[0] = "Bilgisayar Ağları";
            //lessonArray[1] = "Mikroişlemciler";
            //lessonArray[2] = "İşletim Sistemleri";
            //lessonArray[3] = "Bilgisayar Organizasyonu ve Mimarisi";
            //lessonArray[4] = "Diferansiyel Denklemler";


            //indexer kullanımı 


            Lesson lesson = new Lesson();

            lesson[0] = "Bilgisayar Ağları";
            lesson[1] = "Mikroişlemciler";
            lesson[2] = "İşletim Sistemleri";
            lesson[3] = "Bilgisayar Organizasyonu ve Mimarisi";
            lesson[4] = "Diferansiyel Denklemler";

            Console.WriteLine(lesson[1]);
        }
    }
}
