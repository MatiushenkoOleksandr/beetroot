using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson20
{
    public class PersonCollectionMoch
    {
        public List<PersonInfo> Persons { get; set; }
        public PersonCollectionMoch(int count)
        {
            var personFaker = new Faker<PersonInfo>()
                .RuleFor(p => p.Id, f => f.UniqueIndex)
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Email, (f,p) => f.Internet.Email(p.FirstName))
                .RuleFor(p => p.DateOfBirth, f => f.Date.Past(45, DateTime.Now.AddYears(-17)))
                .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber());
            Persons = personFaker.Generate(count);


        }




}
    
}
