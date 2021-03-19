namespace partial_class_exercise.Partial_Classes
{
    public partial class Movie
    {
        public Movie()
        {

        }
        public void AddMovie(string name, double imdb)
        {
            this.Name = name;
            this.Imdb = imdb;
        }
            
    }
}
