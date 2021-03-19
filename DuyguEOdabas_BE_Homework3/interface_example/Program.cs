using interface_example.Sample;
using System;

namespace interface_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Cember cember = new Cember();
            cember.alanHesapla(5);
            cember.cevreHesapla(12);
            Kare kare = new Kare();
            kare.alanHesapla(4);
            kare.cevreHesapla(10);

        }
    }
}
