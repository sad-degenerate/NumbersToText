namespace NumbersToText
{
    public class TextFromNumbers
    {
        private readonly List<string> _numberInWords = new();

        public string Make(long number)
        {
            _numberInWords.Clear();

            if (number == 0)
                return "ноль";

            if (number < 0)
                _numberInWords.Add("минус");

            number = Math.Abs(number);

            Billions(number / 1_000_000_000);
            Millions(number / 1_000_000 % 1_000);
            Thousands(number / 1_000 % 1_000);
            TensAndHoundreds(number % 1_000);

            return CreateResultString();
        }

        private string CreateResultString()
        {
            var resultString = string.Empty;
            foreach (var word in _numberInWords)
                if (string.IsNullOrWhiteSpace(word) == false)
                    resultString += $"{word} ";

            return resultString;
        }

        private void TensAndHoundreds(long number)
        {
            _numberInWords.Add(NumbersToTextArrays.Houndreds[number / 100]);
            _numberInWords.Add(NumbersToTextArrays.Tens[number % 100 / 10]);
            if (number % 100 >= 20)
                _numberInWords.Add(NumbersToTextArrays.Ones[number % 10]);
            else
                _numberInWords.Add(NumbersToTextArrays.Ones[number % 20]);
        }

        private void Thousands(long number)
        {
            if (number == 0)
                return;

            TensAndHoundreds(number);

            AddRank(NumbersToTextArrays.ThousandCases, (int)number % 100);
        }

        private void Millions(long number)
        {
            if (number == 0)
                return;

            TensAndHoundreds(number);

            AddRank(NumbersToTextArrays.MillionCases, (int)number % 100);
        }

        private void Billions(long number)
        {
            if (number == 0)
                return;

            TensAndHoundreds(number);

            AddRank(NumbersToTextArrays.BillionCases, (int)number % 100);
        }

        private void AddRank(Dictionary<NumberRange, string> rankCases, int tens)
        {
            foreach (var _case in rankCases)
            {
                if (_case.Key.IsInRange(tens))
                {
                    _numberInWords.Add(_case.Value);
                    break;
                }
            }
        }
    }
}