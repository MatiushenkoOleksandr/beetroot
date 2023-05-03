
using lesson19;
using Newtonsoft.Json;

var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("D:\\Git\\repository\\repo\\lesson19\\People.json")).ToList();
var person1 = persons.Max(a => a.Latitude);
var person2 = persons.Min(a => a.Latitude);
var person3 = persons.Max(b => b.Longitude);
var person4 = persons.Min(b => b.Longitude);
var minDistance = persons[0].GetDistance(persons[1]);
var maxDistance = persons[0].GetDistance(persons[1]);

for (int i = 0; i < persons.Count - 1; i++)
{
    for (int j = i + 1; j < persons.Count; j++)
    {
        var distance = persons[i].GetDistance(persons[j]);
        if (distance < minDistance)
        {
            minDistance = distance;
        }
        if (distance > maxDistance)
        {
            maxDistance = distance;
        }

    }
}

var twoPersonsWithSameWords = persons.SelectMany(r => persons.Where(m => m.Id != r.Id).Select(p => p.GetCountOfSameWords(r)));
var firstPersonWithSameFriend = new Person();
var secondPersonWithSameFriend = new Person();

for (int i = 0; i < persons.Count; i++)
{
    var sameFriendPerson = persons.FirstOrDefault(a => a.Id != persons[i].Id && a.GetSameFriends(persons[i]) > 0);
   firstPersonWithSameFriend= sameFriendPerson;
    secondPersonWithSameFriend = persons[i];
    if (sameFriendPerson != null)
    {
        break;
    } 
}

//var m = persons.Select(p => persons.Where(m => m.Id != p.Id && p.GetSameFriends(m) > 0).ToList()).ToList();

//var r = persons.SelectMany(r => persons.Where(m => m.Id != r.Id).Select(p => p.GetDistance(r))).Min();
//var b = persons.SelectMany(r => persons.Where(m => m.Id != r.Id).Select(p => p.GetDistance(r))).Max();
//var newList = persons.Select(a => a.GetDistance(persons[5])).ToList();
