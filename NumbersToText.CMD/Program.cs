using NumbersToText.LIB;

Console.WriteLine("Добро пожаловать!");
Console.WriteLine("Вводите любые числа от 999 999 999 999 до - 999 999 999 999 (чтобы выйти введите НЕ число)\n");

while (true)
{
    Console.WriteLine("Введите число: ");
    var input = Console.ReadLine();
    if (long.TryParse(input, out long number) == false)
        break;

    var text = TextFromNumbers.Make(number);

    Console.WriteLine("Вы ввели это число: " + text + "\n");
}