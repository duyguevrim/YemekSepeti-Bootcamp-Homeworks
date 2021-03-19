using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Hw_5.Model;
using Microsoft.Extensions.Configuration;


namespace Hw_5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILogger<LessonController> _logger;
        private readonly IConfiguration _configuration;

        public LessonController(ILogger<LessonController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        [HttpGet]
        public ActionResult<IEnumerable<LessonModel>> DapperSelectInQuery()
        {
            IEnumerable<LessonModel> lessons = new List<LessonModel>();

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                lessons = db.Query<LessonModel>("SELECT * FROM Lessons");

            }
            return new ActionResult<IEnumerable<LessonModel>>(lessons);
        }

        [HttpPost]
        public IActionResult DapperInsert([FromBody] LessonModel lessonModel)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    if (db.State != ConnectionState.Open)
                        db.Open();

                    db.Execute(@"INSERT INTO Lessons (LessonId, StudentID, LessonName)
                         VALUES(@LessonId,@StudentID,@LessonName)", lessonModel);
                    return Ok(lessonModel);
                }

            }
            catch (Exception error)
            {
                _logger.LogInformation("There was a problem inserting the lesson.");
            }

            return Ok(lessonModel);

        }
    }
}