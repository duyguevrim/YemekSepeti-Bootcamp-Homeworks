using System;
using System.Collections.Generic;
using System.Text;

namespace interface_example.Sample
{
    class Kare : Islem
    {
        public void alanHesapla(int sayi)
        {
            Console.WriteLine("Kare Alani : " + Math.Pow(sayi, 2));
        }

        public void cevreHesapla(int sayi)
        {
            Console.WriteLine("Kare Çevresi : " + 4* sayi);
        }
    }
}
