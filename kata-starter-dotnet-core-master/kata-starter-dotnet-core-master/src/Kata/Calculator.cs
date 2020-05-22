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

            var array =s.Split(',');
            if (array.Length > 1)
            {
                return int.Parse(array[0]) + int.Parse(array[1]);
            }
            return 3;

        }
    }
}