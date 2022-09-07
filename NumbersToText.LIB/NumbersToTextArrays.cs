namespace NumbersToText.LIB
{
    public class NumbersToTextArrays
    {
        private readonly string[] _houndreds;
        private readonly string[] _tens;
        private readonly string[] _ones;

        public NumbersToTextArrays()
        {
            _houndreds = new string[]
            {
                "",
                "сто",
                "двести",
                "триста",
                "четыреста",
                "пятьсот",
                "шестьсот",
                "семьсот",
                "восемьсот",
                "девятьсот",
            };

            _tens = new string[]
            {
                "",
                "двадцать",
                "тридцать",
                "сорок",
                "пятьдесят",
                "шестьдесят",
                "семьдесят",
                "восемьдесят",
                "девяносто",
            };

            _ones = new string[]
            {
                "",
                "один",
                "два",
                "три",
                "четыре",
                "пять",
                "шесть",
                "семь",
                "восемь",
                "девять",
                "десять",
                "одиннадцать",
                "двенадцать",
                "тринадцать",
                "четырнадцать",
                "пятнадцать",
                "шестнадцать",
                "семнадцать",
                "восемнадцать",
                "девятнадцать",
            };
        }

        public string[] GetHoundreds()
        {
            return _houndreds;
        }

        public string[] GetTens()
        {
            return _tens;
        }

        public string[] GetOnes()
        {
            return _ones;
        }
    }
}