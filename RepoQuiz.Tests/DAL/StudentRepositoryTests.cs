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
    }
}
