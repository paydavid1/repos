using System;
using System.Linq;

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

            string[] separators = {",", "\n", "/", ";"};
            
            var numbers =s.Split(separators,StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var negatives = numbers.Where(i => i < 0);
            
            
            
            if (negatives.Any())
                throw new Exception($"negatives not allowed: {string.Join((negatives.Count()== 1 ? "":","), negatives.Select(i => i.ToString()))}");
 
            
            return numbers.Sum();

        }
    }
}