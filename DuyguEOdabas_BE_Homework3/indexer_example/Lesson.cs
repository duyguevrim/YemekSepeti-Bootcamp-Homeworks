using System;
using System.Collections.Generic;
using System.Text;

namespace indexer_example
{
    class Lesson
    {
        public string Name { get; set; }
        public int ID { get; set; }

        //indexer tanımlaması
        private string[] names = new string[5];
        public string this[int index]
        {
            get
            {
                return names[index];
            }
            set
            {
                names[index] = value;
            }
        }
    }

}

