var xString = Console.ReadLine();
var yString = Console.ReadLine();
var canConvertX = int.TryParse(xString, out int x);
var canConvertY = int.TryParse(yString, out int y);
if (!canConvertX)
{
    Console.WriteLine("Помилка введення");
}
if (!canConvertY)
{
    Console.WriteLine("Помилка введення");
}
var sum = 0;
if (x < y)
{
    for (int i = x; i <= y; i++)
    {
        sum = sum + i;
    }
}
else
{
    for (int i = x; i >= y; i--)
    {
        sum = sum + i;
    }
}


//if (x > y)
//{
//    var a = x;
//    x = y;
//    y = a;
//}

//for (int i = x; i <= y; i++)
//{
//    sum = sum + i;
//}

Console.WriteLine(sum);

