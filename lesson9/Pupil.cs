using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson9
{
    public class Pupil
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Class Class { get; set; }

        public List<Schedule> GetSchedulesForDay(Weekday day)
        {
            var lessonList = new List<Schedule>();

            for (int i = 0; i < Class.Schedules.Count; i++)
            {
                if (Class.Schedules[i].Day == day)
                {
                    lessonList.Add(Class.Schedules[i]);
                }
            }

            //foreach (var lesson in Class.Schedules)
            //{
            //    if (lesson.Day == day)
            //    {
            //        lessonList.Add(lesson);
            //    }
            //}

            return lessonList;
        }
        public Schedule GetLessonForToday(Weekday day, int number)

        {
            for (int i = 0;i< Class.Schedules.Count;i++)
            {
                if (Class.Schedules[i].Day==day&&Class.Schedules[i].LessonNumber==number)
                {
                    return Class.Schedules[i];
                }
            }
            return new Schedule();
        }
        public void PupilNameAndClass()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Class.Name);
        }
    }
}

