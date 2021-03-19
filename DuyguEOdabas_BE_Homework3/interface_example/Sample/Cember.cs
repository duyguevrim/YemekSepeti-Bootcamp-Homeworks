using System;
using System.Collections.Generic;
using System.Text;

namespace interface_example.Sample
{
    class Cember : Islem
    {
        public void alanHesapla(int sayi)
        {
            Console.WriteLine("Çember Alanı : " + Math.PI* Math.Pow(sayi, 2));
        }

        public void cevreHesapla(int sayi)
        {
            Console.WriteLine("Çember Çevresi : " + 2*Math.PI* sayi);
        }
    }
}
