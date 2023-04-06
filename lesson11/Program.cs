using lesson11;

string[] lines = File.ReadAllLines("Text.txt");
foreach (var aaaa in lines)
{
    Console.WriteLine(aaaa);
}

var helper = new StringSearchHealper();
var searchKey = Console.ReadLine();
var help = helper.Search1(lines,searchKey);
foreach(var line in help)
{
    Console.WriteLine(line);
}

