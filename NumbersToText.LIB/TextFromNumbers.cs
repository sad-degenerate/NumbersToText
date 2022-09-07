namespace NumbersToText.LIB
{
    public class TextFromNumbers
    {
        private readonly List<string> _numberInWords;

        public TextFromNumbers()
        {
            _numberInWords = new List<string>();
        }

        public string Make(long number)
        {
            if (number == 0)
                return "ноль";

            if (number < 0)
                _numberInWords.Add("минус");

            number = Math.Abs(number);

            Billions(number / 1000000000);
            Millions(number / 1000000 % 1000);
            Thousands(number / 1000 % 1000);
            TensAndHoundreds(number % 1000);

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
            var lastWord = _numberInWords.Last();

            if (lastWord.Contains("один") && lastWord != "одиннадцать")
            {
                _numberInWords[^1] = _numberInWords.Last().Replace("один", "одна");
                _numberInWords.Add("тысяча");
            }
            else if (lastWord.Contains("два"))
            {
                _numberInWords[^1] = _numberInWords.Last().Replace("два", "две");
                _numberInWords.Add("тысячи");
            }
            else if (lastWord.EndsWith("три"))
                _numberInWords.Add("тысячи");
            else if (lastWord.EndsWith("четыре"))
                _numberInWords.Add("тысячи");
            else
                _numberInWords.Add("тысяч");
        }

        private void Millions(long number)
        {
            if (number == 0)
                return;

            TensAndHoundreds(number);
            var lastWord = _numberInWords.Last();

            if (lastWord.EndsWith("один"))
                _numberInWords.Add("миллион");
            else if (lastWord.EndsWith("два"))
                _numberInWords.Add("миллиона");
            else if (lastWord.EndsWith("три"))
                _numberInWords.Add("миллиона");
            else if (lastWord.EndsWith("четыре"))
                _numberInWords.Add("миллиона");
            else
                _numberInWords.Add("миллионов");
        }

        private void Billions(long number)
        {
            if (number == 0)
                return;

            TensAndHoundreds(number);
            var lastWord = _numberInWords.Last();

            if (lastWord.EndsWith("один"))
                _numberInWords.Add("миллиард");
            else if (lastWord.EndsWith("два"))
                _numberInWords.Add("миллиарда");
            else if (lastWord.EndsWith("три"))
                _numberInWords.Add("миллиарда");
            else if (lastWord.EndsWith("четыре"))
                _numberInWords.Add("миллиарда");
            else
                _numberInWords.Add("миллиардов");
        }
    }
}