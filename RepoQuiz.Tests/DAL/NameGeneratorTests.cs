﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using RepoQuiz.Models;
using System.Collections.Generic;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class NameGeneratorTests
    {
        [TestMethod]
        public void NameGeneratorCanBeInstantiated()
        {
            NameGenerator testGen = new NameGenerator();

            Assert.IsNotNull(testGen);
        }

        [TestMethod]
        public void NameGeneratorCanGenerateStudents()
        {
            NameGenerator testGen = new NameGenerator();
            Student actual_student = testGen.GenerateRandomStudent();

            Assert.IsInstanceOfType(actual_student, typeof(Student));
        }

        [TestMethod]
        public void NameGeneratorGeneratesFirstNamesCorrectly()
        {
            NameGenerator testGen = new NameGenerator();
            List<string> testList = new List<string> { "Lisa", "Frank", "Thor", "Odin", "Matt", "Bobby", "Lunchbox", "Sally", "Beth", "Layla", "Ryan", "Paul", "Dan", "Abbie", "Sandy", "Brad", "Callan", "Janelle", "Dhru", "Katye", "Zach", "Joe", "Zoe", "Kate", "Will", "John", "Jurnell", "Blaise", "Tim", "Odie", "Sylvia", "Lunchbox", "Ziggy", "Donald", "Jack", "Emily", "Patricia" };
            Student testStudent = testGen.GenerateRandomStudent();

            Assert.IsTrue(testList.Contains(testStudent.FirstName));
        }

        [TestMethod]
        public void NameGeneratorGeneratesLastNamesCorrectly()
        {
            NameGenerator testGen = new NameGenerator();
            List<string> testList = new List<string> { "Williams", "Roberts", "Dogskin", "Miller", "Bruton", "Cooper", "Li", "Smith", "Ryan", "Obama", "Parris", "Anderson", "Manson", "Walters", "Danzig", "Ford", "Washington", "Lincoln", "Bates" };
            Student testStudent = testGen.GenerateRandomStudent();

            Assert.IsTrue(testList.Contains(testStudent.LastName));
        }

        [TestMethod]
        public void NameGeneratorGeneratesMajorsCorrectly()
        {
            NameGenerator testGen = new NameGenerator();
            List<string> testList = new List<string> { "Journalism", "Basket Weaving", "English", "Stamp Collection", "Cave Drawings", "Unicorn Acquisition", "Crab Finding", "Dog Grooming", "Pig Noises", "Advanced Water Boiling" };
            Student testStudent = testGen.GenerateRandomStudent();

            Assert.IsTrue(testList.Contains(testStudent.Major));
        }

        [TestMethod]
        public void NameGeneratorStudentIsCreatedWithValuesInAllProperties()
        {
            NameGenerator testGen = new NameGenerator();
            Student test_student = testGen.GenerateRandomStudent();

            Assert.IsNotNull(test_student.FirstName);
            Assert.IsNotNull(test_student.LastName);
            Assert.IsNotNull(test_student.Major);
        }
    }
}
