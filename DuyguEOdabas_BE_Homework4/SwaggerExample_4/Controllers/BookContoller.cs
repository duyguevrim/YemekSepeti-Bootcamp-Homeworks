using Microsoft.AspNetCore.Mvc;
using SwaggerExample_4.Data;
using SwaggerExample_4.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerExample_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookContoller : ControllerBase
    {
        private AppDbContext _context;

        public BookContoller(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            List<Book> books = _context.Books.ToList();
            return Ok(books);
        }

       

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _context.Add(book);
            return Ok();
        }
    }
}
