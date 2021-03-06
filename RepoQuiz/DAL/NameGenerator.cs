﻿using RepoQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoQuiz.DAL
{
    public class NameGenerator
    {
        private string generated_first_name { get; set; }
        private string generated_last_name { get; set; }
        private string generated_major { get; set; }

        private List<string> FirstNames = new List<string>() { "Lisa", "Frank", "Thor", "Odin", "Matt", "Bobby", "Lunchbox", "Sally", "Beth", "Layla", "Ryan", "Paul", "Dan", "Abbie", "Sandy", "Brad", "Callan", "Janelle", "Dhru", "Katye", "Zach", "Joe", "Zoe", "Kate", "Will", "John", "Jurnell", "Blaise", "Tim", "Odie", "Sylvia", "Lunchbox", "Ziggy", "Donald", "Jack", "Emily", "Patricia" };

        private List<string> LastNames = new List<string>() { "Williams", "Roberts", "Dogskin", "Miller", "Bruton", "Cooper", "Li", "Smith", "Ryan", "Obama", "Parris", "Anderson", "Manson", "Walters", "Danzig", "Ford", "Washington", "Lincoln", "Bates" };

        private List<string> Majors = new List<string>() { "Journalism", "Basket Weaving", "English", "Stamp Collection", "Cave Drawings", "Unicorn Acquisition", "Crab Finding", "Dog Grooming", "Pig Noises", "Advanced Water Boiling" };

        private string GenerateRandomStringFromList(List<string> target_list)
        {
            string random_string = target_list[RandomNumberGenerator.GenerateRandomNumberStartingAtZero(target_list.Count)];
            return random_string;
        }
        public Student GenerateRandomStudent()
        {
            Student generated_student = new Student() { FirstName = GenerateRandomStringFromList(FirstNames), LastName = GenerateRandomStringFromList(LastNames), Major = GenerateRandomStringFromList(Majors) };
            return generated_student;
        }
    }
}