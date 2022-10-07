namespace Sparky
{
    public class Calculator
    {
        public List<int> NumberRange = new();
        public int AddNumber(int a, int b)
        {
            return a + b;
        }

        public bool IsOddNumber(int a) { 
            return a % 2 != 0;
        }

        public List<int> GetOddRange(int min, int max)
        {
            NumberRange.Clear();
            for(int i = min; i <= max; i++)
            {
                if(i % 2 != 0){
                    NumberRange.Add(i);
                }
            }
            return NumberRange;
        }
    }
}