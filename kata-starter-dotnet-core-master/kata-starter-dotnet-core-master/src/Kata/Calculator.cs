﻿using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Sum(string s = "")
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var numbers =s.Split(',').Select(int.Parse);
            return numbers.Sum();

        }
    }
}