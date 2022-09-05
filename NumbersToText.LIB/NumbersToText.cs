using System.Text;

namespace NumbersToText.LIB
{
    public static class NumbersToText
    {
        public static string Make(int number)
        {
            if (number == 0)
                return "ноль";

            var builder = new StringBuilder();

            if (number < 0)
                builder.Append("минус ");

            var absNumber = Math.Abs(number);

            var result = Billions(builder, number);
            
            return result.ToString();
        }

        private static StringBuilder TensAndHoundreds(StringBuilder builder, int number)
        {
            builder.Append((number / 100) switch
            {
                1 => "сто ",
                2 => "двести ",
                3 => "триста ",
                4 => "четыреста ",
                5 => "пятьсот ",
                6 => "шестьсот ",
                7 => "семьсот ",
                8 => "восемьсот ",
                9 => "девятьсот ",
                _ => ""
            });

            builder.Append((number / 10 % 10) switch
            {
                2 => "двадцать ",
                3 => "тридцать ",
                4 => "сорок ",
                5 => "пятьдесят ",
                6 => "шестьдесят ",
                7 => "семьдесят ",
                8 => "восемьдесят ",
                9 => "девяносто ",
                _ => ""
            });

            builder.Append((number >= 20 ? number % 10 : number % 20) switch
            {
                1 => "один ",
                2 => "два ",
                3 => "три ",
                4 => "четыре ",
                5 => "пять ",
                6 => "шесть ",
                7 => "семь ",
                8 => "восемь ",
                9 => "девять ",
                10 => "десять ",
                11 => "одиннадцать ",
                12 => "двенадцать ",
                13 => "тринадцать ",
                14 => "четырнадцать ",
                15 => "пятнадцать ",
                16 => "шестнадцать ",
                17 => "семнадцать ",
                18 => "восемнадцать ",
                19 => "девятнадцать ",
                _ => ""
            });

            return builder;
        }

        private static StringBuilder Thousands(StringBuilder builder, int number)
        {
            if (number / 1000 == 0)
                return TensAndHoundreds(builder, number);

            builder = TensAndHoundreds(builder, number / 1000);
            var lastWord = builder.ToString().Split(' ').Last();

            if (lastWord.EndsWith("один"))
            {
                builder.Remove(builder.Length - 5, builder.Length);
                builder.Append("одна ");
                builder.Append("тысяча ");
            }
            else if (lastWord.EndsWith("два "))
            {
                builder.Remove(builder.Length - 4, builder.Length);
                builder.Append("две ");
                builder.Append("тысячи ");
            }
            else if (lastWord.EndsWith("три "))
            {
                builder.Append("тысячи ");
            }
            else if (lastWord.EndsWith("четыре "))
            {
                builder.Append("тысячи ");
            }
            else
            {
                builder.Append("тысяч ");
            }

            return TensAndHoundreds(builder, number);
        }

        private static StringBuilder Millions(StringBuilder builder, int number)
        {
            if (number / 1000000 == 0)
                return Thousands(builder, number);

            builder = TensAndHoundreds(builder, number / 1000000);
            var lastWord = builder.ToString().Split(' ').Last();

            if (lastWord.EndsWith("один"))
                builder.Append("миллион ");
            else if (lastWord.EndsWith("два "))
                builder.Append("миллиона ");
            else if (lastWord.EndsWith("три "))
                builder.Append("миллиона ");
            else if (lastWord.EndsWith("четыре "))
                builder.Append("миллиона ");
            else
                builder.Append("миллионов ");

            return Thousands(builder, number);
        }

        private static StringBuilder Billions(StringBuilder builder, int number)
        {
            if (number / 1000000000 == 0)
                return Millions(builder, number);

            builder = TensAndHoundreds(builder, number / 1000000000);
            var lastWord = builder.ToString().Split(' ').Last();

            if (lastWord.EndsWith("один"))
                builder.Append("миллиард ");
            else if (lastWord.EndsWith("два "))
                builder.Append("миллиарда ");
            else if (lastWord.EndsWith("три "))
                builder.Append("миллиарда ");
            else if (lastWord.EndsWith("четыре "))
                builder.Append("миллиарда ");
            else
                builder.Append("миллиардов ");

            return Millions(builder, number);
        }
    }
}