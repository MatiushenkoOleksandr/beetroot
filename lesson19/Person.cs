using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson19
{
    public enum Gender
    {
        male,
        female,
    }

    public class Friend
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Person
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("guid")]
        public Guid GuidId { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("eyeColor")]
        public string EyeColor { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("registered")]
        public string Registered { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("friends")]
        public List<Friend> Friends { get; set; }

        public double GetDistance(Person person)
        {
            var distanceX = Longitude - person.Longitude;
            var distanceY = Latitude - person.Latitude;
            var distance = distanceX * distanceX + distanceY * distanceY;
            distance = Math.Sqrt(distance);

            return distance;
        }

        public int GetCountOfSameWords(Person person)
        {
            var words = About.Split(" ");
            var words2 = person.About.Split(" ");
            var count = words.Where(a=> words2.Any(b=> a.Contains(b))).Count();
            return count;

        }
        public int GetSameFriends(Person person)
        {
            var names = Friends.Select(a => a.Name.Split(" ")[0]).Intersect(person.Friends.Select(b => b.Name.Split(" ")[0])).ToList();
            return names.Count;
        }

    }
}
