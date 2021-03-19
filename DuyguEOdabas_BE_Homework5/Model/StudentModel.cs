using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hw_5.Model
{
    public class StudentModel
    {
        public int ID { get; set; }

        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentNumber { get; set; }
        public List<LessonModel> lesson { get; set; }
 
    }
}