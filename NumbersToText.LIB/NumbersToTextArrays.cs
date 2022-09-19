namespace NumbersToText
{
    public static class NumbersToTextArrays
    {
        public static string[] Houndreds { get; } = new string[]
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

        public static string[] Tens { get; } = new string[]
        {
            "",
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

        public static string[] Ones { get; } = new string[]
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

        public static Dictionary<NumberRange, string> ThousandCases { get; } = new Dictionary<NumberRange, string>()
        {
            { new NumberRange(0, 0), "тысяч" },
            { new NumberRange(1, 1), "тысяча" },
            { new NumberRange(2, 4), "тысячи" },
            { new NumberRange(5, 999), "тысяч" },
        };

        public static Dictionary<NumberRange, string> MillionCases { get; } = new Dictionary<NumberRange, string>()
        {
            { new NumberRange(0, 0), "миллионов" },
            { new NumberRange(1, 1), "миллион" },
            { new NumberRange(2, 4), "миллиона" },
            { new NumberRange(5, 999), "миллионов" },
        };

        public static Dictionary<NumberRange, string> BillionCases { get; } = new Dictionary<NumberRange, string>()
        {
            { new NumberRange(0, 0), "миллиардов" },
            { new NumberRange(1, 1), "миллиард" },
            { new NumberRange(2, 4), "миллиарда" },
            { new NumberRange(5, 999), "миллиардов" },
        };
    }
}