using lesson_15;
using System.Globalization;
var voteList = new List<Vote>();
var enteringVote = true;
while (enteringVote)
{
    Console.WriteLine("Enter question");
    var vote = new Vote()

    {
        Question = Console.ReadLine(),
        Id = 0,
        Options = new Dictionary<int, string>(),
    };
    var numberOfOptionsEntered = true;
    int optionsCount=0;
    while (numberOfOptionsEntered)
    {
        Console.WriteLine("Enter number of options");
        var optionsCountString = Console.ReadLine();
       
        var ifInt = int.TryParse(optionsCountString, out optionsCount);
        numberOfOptionsEntered = !ifInt;

    }
    for (int i = 1; i < optionsCount+1; i++)
    {
        Console.WriteLine($"Enter option {i}");
        var question = Console.ReadLine();
        vote.Options.Add(i, question);
    }
    var numberOfCorectAnswer = true;
    while (numberOfCorectAnswer)
    {
        Console.WriteLine("Enter correct answer");
        var correctAnswerString = Console.ReadLine();
        int correctAnswer = 0;
        var ifInt = int.TryParse(correctAnswerString, out correctAnswer);
       if (ifInt && correctAnswer<=optionsCount)
        {
            vote.CorrectAnswer = correctAnswer;
            numberOfCorectAnswer = false;

        }
    }
    Console.WriteLine("Do you want continue? Press 1 if YES.");
    var answer=Console.ReadLine();
    voteList.Add(vote);
    if (answer != "1")
    {
        enteringVote = false;
    }
    
}
int correctAnswersCount = 0;
for (int i = 0; i < voteList.Count; i++)
{
    Console.WriteLine(voteList[i].Question);
    for (int j = 1; j < voteList[i].Options.Count+1; j++)
    {
        Console.WriteLine($"{j}. {voteList[i].Options[j]}");
    }
    var enterdAnswer = Console.ReadLine();
    if 
        
       ( enterdAnswer == voteList[i].CorrectAnswer.ToString())
    {
        correctAnswersCount++;
    }

    
}
Console.WriteLine("Your count of correct answers");
Console.WriteLine(correctAnswersCount.ToString());

