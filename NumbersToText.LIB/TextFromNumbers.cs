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
                resultString += $"{word} ";

            return resultString;
        }

        private void TensAndHoundreds(long number)
        {
            var hundreds = (number / 100 % 100);
            if (hundreds > 10)
                hundreds %= 10;

            _numberInWords.Add(hundreds switch
            {
                1 => "сто",
                2 => "двести",
                3 => "триста",
                4 => "четыреста",
                5 => "пятьсот",
                6 => "шестьсот",
                7 => "семьсот",
                8 => "восемьсот",
                9 => "девятьсот",
                _ => ""
            });

            _numberInWords.Add((number / 10 % 10) switch
            {
                2 => "двадцать",
                3 => "тридцать",
                4 => "сорок",
                5 => "пятьдесят",
                6 => "шестьдесят",
                7 => "семьдесят",
                8 => "восемьдесят",
                9 => "девяносто",
                _ => ""
            });

            _numberInWords.Add((number >= 20 ? number % 10 : number % 20) switch
            {
                1 => "один",
                2 => "два",
                3 => "три",
                4 => "четыре",
                5 => "пять",
                6 => "шесть",
                7 => "семь",
                8 => "восемь",
                9 => "девять",
                10 => "десять",
                11 => "одиннадцать",
                12 => "двенадцать",
                13 => "тринадцать",
                14 => "четырнадцать",
                15 => "пятнадцать",
                16 => "шестнадцать",
                17 => "семнадцать",
                18 => "восемнадцать",
                19 => "девятнадцать",
                _ => ""
            });
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


            if (lastWord.Contains("один"))
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