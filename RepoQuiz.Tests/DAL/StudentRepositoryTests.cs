using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.Models;
using RepoQuiz.DAL;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class StudentRepositoryTests
    {
        Mock<StudentContext> mock_context { get; set; }
        Mock<DbSet<Student>> mock_student_table { get; set; }
        List<Student> student_list { get; set; }
        StudentRepository repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var queryable_list = student_list.AsQueryable();

            mock_student_table.As<IQueryable<Student>>().Setup(x => x.Provider).Returns(queryable_list.Provider);
            mock_student_table.As<IQueryable<Student>>().Setup(x => x.Expression).Returns(queryable_list.Expression);
            mock_student_table.As<IQueryable<Student>>().Setup(x => x.ElementType).Returns(queryable_list.ElementType);
            mock_student_table.As<IQueryable<Student>>().Setup(x => x.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(x => x.Students).Returns(mock_student_table.Object);

            mock_student_table.Setup(t => t.Add(It.IsAny<Student>())).Callback((Student v) => student_list.Add(v));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<StudentContext>();
            mock_student_table = new Mock<DbSet<Student>>();
            student_list = new List<Student>();
            repo = new StudentRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }
        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void EnsureStudentRepositoryCanBeInstantiated()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureRepoHasContext()
        {
            StudentContext expected_context = repo.Context;
            Assert.IsInstanceOfType(expected_context, typeof(StudentContext));
        }

        [TestMethod]
        public void RepoEnsureNoStudentsStoredByDefault()
        {
            List<Student> actual_students = repo.GetStudents();

            int expected_student_count = 0;
            int actual_student_count = actual_students.Count;

            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void RepoEnsureGetStudentsReturnsAllStudentsWhenStudentsExist()
        {
            NameGenerator name_gen = new NameGenerator();
            student_list.Add(name_gen.GenerateRandomStudent());

            List<Student> actual_students = repo.GetStudents();
            int actual_student_count = actual_students.Count;
            int expected_student_count = 1;

            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void RepoEnsureGetStudentByIdReturnsCorrectStudent()
        {
            Student student1 = new Student { StudentID = 1, FirstName = "Student", LastName = "One", Major = "Stuff" };
            Student student2 = new Student { StudentID = 2, FirstName = "Student", LastName = "Two", Major = "Things" };

            student_list.Add(student1);
            student_list.Add(student2);

            Student expected_student = student2;
            Student actual_student = repo.GetStudentById(2);

            Assert.AreEqual(expected_student, actual_student);         
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RepoGetStudentByIdThrowsExceptionWhenNoStudentWithIdPresent()
        {
            int actual_student_id = repo.GetStudentById(2).StudentID;
            int expected_student_id = 2;

            Assert.AreEqual(expected_student_id, actual_student_id);
        }
    }
}
