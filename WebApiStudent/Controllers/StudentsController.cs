using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiStudent.Models;

namespace WebApiStudent.Controllers
{
    [RoutePrefix("api/students")]   //routing prefix
    public class StudentsController : ApiController
    {
        static List<Student> student = new List<Student>()
        {
            new Student{id=1,name="Tom"},
            new Student{id=2,name="Jerry"},
            new Student{id=3,name="Faraz"}
        };

        [Route("")]
        public IEnumerable<Student> Get()
        {
            return student;
        }

        //[Route("api/students/{id}")]
        [Route("{id}")]
        public Student Get(int id)
        {
            return student.FirstOrDefault(s => s.id == id);
        }

        //[Route("api/students/{id}/courses")]
        [Route("{id}/courses")]
        public IEnumerable<string> GetStudentCourse(int id)
        {
            if (id == 1)
            {
                return new List<string> { "C#", "ASP.Net"};
            }
            else if (id == 2)
            {
                return new List<string> { "C#",  "Web API" };
            }
            else if (id == 3)
            {
                return new List<string> { "C#", "ASP.Net", "Ado.Net", "Web API" };
            }
            else
            {
                return new List<string> { "Invalid Id given." };
            }
        }

        [Route("~/api/teachers")]    //overriding routing prefix
        public IEnumerable<Teacher> GetTechers() 
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher{id=1,name="Rom"},
                new Teacher{id=2,name="Werry"},
                new Teacher{id=3,name="SarFaraz"}
            };
            return teachers;
        }
    }
}
