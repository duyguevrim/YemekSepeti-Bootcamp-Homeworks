using System;
using System.Collections.Generic;
using System.Text;

namespace inheritance_example.Classes
{
    class Sekil //Base Class
    {
        public double width;
        public double height;
        public void Goster()
        {
            Console.WriteLine("Genişlik: " + width + ", Yükseklik: " + height);
        }
    }
}
