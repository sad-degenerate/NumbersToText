namespace NumbersToText.LIB
{
    public class NumberRange
    {
        private readonly int _start;
        private readonly int _end;

        public NumberRange(int start, int end) => (_start, _end) = (start, end);

        public bool IsInRange(int number)
        {
            return number >= _start && number <= _end;
        }
    }
}