using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson9
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Schedule> Scheduls { get; set; }
        public School School { get; set; }

        public List<Schedule> GetSchedulesForDay(Weekday day)
        {
            var lessonList = new List<Schedule>();

            for (int i = 0; i < Scheduls.Count; i++)
            {
                if (Scheduls[i].Day == day)
                {
                    lessonList.Add(Scheduls[i]);
                }
            }

            return lessonList;


        }
        public Schedule GetLessonForToday(Weekday day, int number)

        {
            for (int i = 0; i < Scheduls.Count; i++)
            {
                if (Scheduls[i].Day == day && Scheduls[i].LessonNumber == number)
                {
                    return Scheduls[i];
                }
            }
            return new Schedule();
        }
        public Teacher() 
        { 
        Scheduls = new List<Schedule>();
        }
    }
}
