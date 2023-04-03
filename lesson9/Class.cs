using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson9
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pupil> Pupils { get; set;}
        public List<Schedule> Schedules { get; set;}

        public void AdSchedule(Schedule lesson)
        {
            Schedules.Add(lesson);
        }

    }
}
