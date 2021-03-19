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
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IConfiguration _configuration;

        public StudentController(ILogger<StudentController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        //SQL sorgusu ile Student tablosundaki tüm verileri çekiyorum
        [HttpGet]
        public ActionResult<IEnumerable<StudentModel>> DapperSelectInQuery()
        {
            IEnumerable<StudentModel> students = new List<StudentModel>();
            Console.WriteLine("get sorgusu");

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();


                Console.WriteLine("get sorgusu");
                students = db.Query<StudentModel>("SELECT * FROM Student");

            }
            return new ActionResult<IEnumerable<StudentModel>>(students);
        }

        //INSERT komutu ile Student tablosuna yeni veri ekliyorum.
        [HttpPost]
        public IActionResult DapperInsert([FromBody] StudentModel studentModel)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    if (db.State != ConnectionState.Open)
                        db.Open();

                    db.Execute(@"INSERT INTO Student (ID, StudentName, StudentSurname, StudentNumber)
                         VALUES(@ID,@StudentName,@StudentSurname,@StudentNumber)", studentModel);
                    return Ok(studentModel);
                }

            }
            catch (Exception error)
            {
                _logger.LogInformation("There was a problem inserting the student.");
            }

            return Ok(studentModel);

        }

        //UPDATE komutu ile ID değerine göre Student tablosundaki ilgili verinin StudentName sütununu güncelliyorum.
        [HttpPut]
        public IActionResult DapperUpdate([FromBody] StudentModel studentModel)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    if (db.State != ConnectionState.Open)
                        db.Open();

                    var result = db.Execute(@"UPDATE Student SET StudentName = @StudentName, 
                                                     WHERE ID = @ID",
                        new
                        {
                            StudentName = studentModel.StudentName
                        });

                    return Ok(studentModel);


                }

            }
            catch (Exception error)
            {
                return BadRequest();
            }
        }


        //ID bilgisine göre Student silme işlemini gerçekleştiriyorum.
        [HttpDelete("{id}")]
        public IActionResult DapperDelete(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    if (db.State != ConnectionState.Open)
                        db.Open();
                    var result = db.Execute(@"DELETE FROM Student WHERE ID=@ID", new { id = id });

                    return Ok();


                }
            }
            catch (Exception error)
            {
                return BadRequest();
            }
        }

        // one-to-one iliskili iki tabloyu Id bilgisine gore kontrol edip bir modele bind ediyorum.
        [HttpGet("oneToOneMap")]
        public IActionResult OneToOneMapping()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                    
                string sql = @"SELECT * FROM dbo.student s inner join Lessons l on s.Id = l.studentId";
                var result = db.Query<StudentModel, LessonModel, StudentModel>(sql, (student, s) =>
                {
                        return student;
                }
                );
                return Ok(result);
                
            }
            return BadRequest("An error!");
        }


        //Burada Student ve Lesson tabloları ile transaction yapıyorum
        [HttpPost()]
        public IActionResult DapperTransactionalInsert([FromBody] StudentModel studentModel)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();

                using (var transaction = db.BeginTransaction())
                {
                    string sql = @"INSERT INTO dbo.student (StudentName, StudentSurname, StudentNumber, ID)
                                                  Values (@StudentName, @StudentSurname, @StudentSurname, @ID);";
                    var result = db.Execute(sql, new
                    {
                        StudentName = "Duygu Evrim",
                        StudentSurname = "Odabaş",
                        StudentNumber = 94,
                        ID = 1,

                    }, transaction);
                    throw new ArgumentNullException();
                    LessonModel lessonModel = new LessonModel()
                    {
                        LessonId = 1,
                        StudentId = 1,
                        LessonName = "Bilgisayar Ağları"
                    };
                    sql = @"Insert into [student].[lesson] (LessonId, StudentId, LessonName)
                                Values (@LessonId, @StudentId, @LessonName)";
                    result = db.Execute(sql, lessonModel, transaction);
                    transaction.Commit();
                }
            }
            return Ok();
        }


        // çoklu komut çalıştırmak için QueryMultiple kullanırız.
        [HttpGet("multiplequery")]
        public IActionResult DapperMultipleQueryMapping()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                if (db.State != ConnectionState.Open)
                    db.Open();

                var querySql = @"SELECT * FROM dbo.student WHERE ID = @Id
                              SELECT * FROM Lessons  WHERE StudentId = @Id";
               
                 var newQuery = db.QueryMultiple(querySql, new { ID = 1 });
                    var student = newQuery.Read<StudentModel>();
                    var lesson = newQuery.Read<LessonModel>();
                    return Ok((student, lesson));
                
            }

            return BadRequest("An Error");
        }

     



    }
}
