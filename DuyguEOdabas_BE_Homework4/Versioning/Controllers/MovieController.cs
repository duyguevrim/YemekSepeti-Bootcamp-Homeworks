using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Versioning.Model;
using Versioning.Services;

namespace Versioning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        public MovieInterface<Movie> _movieService = new MovieService();

        [HttpGet]
        public IActionResult getProducts()
        {
            var response = _movieService.getMovieList();
            return Ok(response);
        }
    }
}
