using System;
using System.Collections.Generic;
using System.Text;

namespace partial_class_exercise.Partial_Classes
{
    public partial class Movie
    {
        private string name;
        private double imdb;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public double Imdb
        {
            get { return this.imdb; }
            set { this.imdb = value; }
        }
    }
}
