using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Versioning.Model;

namespace Versioning.Services
{
    public class MovieService : MovieInterface<Movie>
    {
        public List<Movie> _movies = new List<Movie>();

        public MovieService()
        {
            fillData();
        }
        public Movie getList()
        {
            throw new NotImplementedException();
        }

        public List<Movie> getMovieList()
        {
            return _movies;
        }

        public void fillData()
        {
            
                _movies.Add(new Movie
                {
                    Id = 1,
                    Name = "Dövüş Kulübü",
                    Imdb = 8.8
                });
            _movies.Add(new Movie
            {
                Id = 2,
                Name = "Matrix",
                Imdb = 8.7
            });
            _movies.Add(new Movie
            {
                Id = 3,
                Name = "Yıldızlararası",
                Imdb = 8.6
            });

        }
    }
}
