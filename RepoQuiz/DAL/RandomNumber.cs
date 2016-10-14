using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoQuiz.DAL
{
    public static class RandomNumber
    {
        private static Random r = new Random();
        public static int GenerateRandomNumberStartingAtZero(int max_value)
        {
            int random_int = r.Next(0, max_value);
            return random_int;
        }
    }
}