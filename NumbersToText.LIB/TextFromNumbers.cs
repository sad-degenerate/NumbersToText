﻿namespace NumbersToText.LIB
{
    public class TextFromNumbers
    {
        private readonly List<string> _numberInWords = new();

        public string Make(long number)
        {
            _numberInWords.Clear();

            if (number == 0)
            {
                return "ноль";
            }

            if (number < 0)
            {
                _numberInWords.Add("минус");
            }

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
            for (var i = 0; i < _numberInWords.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(_numberInWords[i]) == false)
                {
                    if (i != 0 && string.IsNullOrWhiteSpace(resultString) == false)
                    {
                        resultString += " ";
                    }

                    resultString += _numberInWords[i];
                }
            }
                    
            return resultString;
        }

        private void TensAndHoundreds(long number)
        {
            _numberInWords.Add(NumbersToTextArrays.Houndreds[number / 100]);
            _numberInWords.Add(NumbersToTextArrays.Tens[number % 100 / 10]);

            if (number % 100 >= 20)
            {
                _numberInWords.Add(NumbersToTextArrays.Ones[number % 10]);
            }
            else
            {
                _numberInWords.Add(NumbersToTextArrays.Ones[number % 20]);
            }
        }

        private void Thousands(long number)
        {
            if (number == 0)
            {
                return;
            }

            TensAndHoundreds(number);

            if (number % 100 % 10 == 1)
            {
                _numberInWords[^1] = "одна";
            }
            else if (number % 100 % 10 == 2)
            {
                _numberInWords[^1] = "две";
            }

            AddRank(NumbersToTextArrays.ThousandCases, (int)number % 100);
        }

        private void Millions(long number)
        {
            if (number == 0)
            {
                return;
            }

            TensAndHoundreds(number);

            AddRank(NumbersToTextArrays.MillionCases, (int)number % 100);
        }

        private void Billions(long number)
        {
            if (number == 0)
            {
                return;
            }

            TensAndHoundreds(number);

            AddRank(NumbersToTextArrays.BillionCases, (int)number % 100);
        }

        private void AddRank(Dictionary<NumberRange, string> rankCases, int tens)
        {
            foreach (var _case in rankCases)
            {
                if (_case.Key.IsInRange(tens % 10))
                {
                    _numberInWords.Add(_case.Value);
                    break;
                }
            }
        }
    }
}