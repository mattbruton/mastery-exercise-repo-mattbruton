using RepoQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoQuiz.DAL
{
    public class StudentRepository
    {
        public StudentContext Context { get; set; }

        public StudentRepository()
        {
            Context = new StudentContext();
        }

        public StudentRepository(StudentContext context)
        {
            Context = context;
        }

        public List<Student> GetStudents()
        {
            return Context.Students.ToList();
        }
    }
}