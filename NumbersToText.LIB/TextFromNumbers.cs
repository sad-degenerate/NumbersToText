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

            Billions(number);

            var resultString = string.Empty;
            foreach (var word in _numberInWords)
                if (string.IsNullOrWhiteSpace(word) == false)
                    resultString += $"{word} ";

            return resultString;
        }

        private void TensAndHoundreds(long number)
        {
            var arrays = new NumbersToTextArrays();

            var hundreds = (number / 100 % 100);
            if (hundreds > 10)
                hundreds %= 10;

            _numberInWords.Add(arrays.GetHoundreds()[hundreds]);
            _numberInWords.Add(arrays.GetTens()[number / 10 % 10]);
            if (number % 100 >= 20)
                _numberInWords.Add(arrays.GetOnes()[number % 10]);
            else
                _numberInWords.Add(arrays.GetOnes()[number % 20]); 
        }

        private void Thousands(long number)
        {
            if (number / 1000 == 0)
            {
                TensAndHoundreds(number);
                return;
            }

            TensAndHoundreds(number / 1000);
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

            TensAndHoundreds(number);
        }

        private void Millions(long number)
        {
            if (number / 1000000 == 0)
            {
                Thousands(number);
                return;
            } 

            TensAndHoundreds(number / 1000000);
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

            Thousands(number);
        }

        private void Billions(long number)
        {
            if (number / 1000000000 == 0)
            {
                Millions(number);
                return;
            }

            TensAndHoundreds(number / 1000000000);
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

            Millions(number);
        }
    }
}