using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using model_dto_validation.Data.Context;
using model_dto_validation.Data.Entity;
using model_dto_validation.Mapping;
using model_dto_validation.RequestModel;
using System.Collections.Generic;
using System.Linq;

namespace model_dto_validation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private DbContextOptions<DatabaseContext> option;
        public BookController()
        {
            option = new DbContextOptionsBuilder<DatabaseContext>()
                   .UseInMemoryDatabase(databaseName: "Book")
                   .Options;

        }
        [HttpGet]
        public IActionResult Get()
        {
            List<BookModel> result = new List<BookModel>();

            using (DatabaseContext dbContext = new DatabaseContext(option))
            {
                var entityList = dbContext.Books.ToList();
                result = entityList.ToBookResponse();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookRequest bookRequest)
        {
            #region validation
            List<string> validations = new List<string>();

            if (bookRequest.name == string.Empty)
            {
                validations.Add("Kitap ismi boş olarak geçilemez");
            }

            if (bookRequest.authorName == string.Empty)
            {
                validations.Add("Yazar ismi boş olarak geçilemez");
            }

            if (bookRequest.page <= 0)
            {
                validations.Add("Kitabın sayfa sayısı 0 ya da daha küçük değer alamaz.");
            }

            if (validations.Any())
                return BadRequest(validations);

            #endregion validation

            using (DatabaseContext context = new DatabaseContext(option))
            {
   
                Book book = bookRequest.ToBook();
                context.Books.Add(book);
                context.SaveChanges();
            }
            return Ok();

        }
        }
    }
