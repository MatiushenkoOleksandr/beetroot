using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson9
{
    public class Schedule
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
         public Weekday Day { get; set; }
        public int LessonNumber { get; set; }
        public Teacher Teacher { get; set; }
        public Class Class { get; set; }

    }
    public enum Weekday
    {
        Monday, Tuesday, Wednesday, Thursday ,Friday,
    }
}

