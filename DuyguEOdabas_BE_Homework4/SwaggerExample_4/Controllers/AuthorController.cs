using Microsoft.AspNetCore.Mvc;
using SwaggerExample_4.Data;
using SwaggerExample_4.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SwaggerExample_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AppDbContext _context;
        public AuthorController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {

            List<Author> authors = _context.Authors.ToList();
            return Ok(authors);
        }

       

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Author author = _context.Authors.FirstOrDefault(author => author.Id == id);
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            _context.Add(author);
            return Ok();
        }
    }
}
