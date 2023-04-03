using lesson9;

var school1 = new School();
school1.Id = 1;
school1.Name = "School #1";
 
var teacher=new Teacher();
teacher.Id = 1;
teacher.Name = "Nicolas Mutter";
teacher.School = school1;
var teacher2=new Teacher();
teacher2.Id = 2;
teacher2.Name = "Fernando Rodriges";
teacher2.School = school1;
var teacher3=new Teacher();
teacher3.Id = 3;
teacher3.Name = "Albert Park";
teacher3.School = school1;


var teachers = new List<Teacher> {
    teacher,teacher2, teacher3
 };
school1.Teachers = teachers;


var class1 = new Class();
class1.Name = "Test";
class1.Id = 1;


var schedule =new Schedule();
schedule.Id = 1;
schedule.LessonName = "Math";
schedule.Day = Weekday.Wednesday;
schedule.LessonNumber = 1;
schedule.Teacher = teacher;
schedule.Class = class1;



var schedule2=new Schedule();
schedule2.Id = 2;
schedule2.LessonName = "History";
schedule2.Day = Weekday.Monday;
schedule2.LessonNumber = 3;
schedule2.Teacher = teacher;
schedule2.Class = class1;

var schedule3 = new Schedule();
schedule3.Id = 3;
schedule3.LessonName = "Physical Traning";
schedule3.Day = Weekday.Thursday;
schedule3.LessonNumber = 3;
schedule3.Teacher= teacher;
schedule3.Class = class1;


var schedule4 = new Schedule();
schedule4.Id = 4;
schedule4.LessonName = "History";
schedule4.Day = Weekday.Friday;
schedule4.LessonNumber = 1;
schedule4.Teacher = teacher;
schedule4.Class = class1;


var schedule5 = new Schedule();
schedule5.Id = 5;
schedule5.LessonName = "Math";
schedule5.Day = Weekday.Tuesday;
schedule5.LessonNumber = 1;
schedule5.Teacher = teacher;
schedule5.Class = class1;

var schedules = new List<Schedule>
{
    schedule, schedule2, schedule3, schedule4, schedule5
};

for (int i = 0; i< schedules.Count; i++)
{
    if (schedules[i].LessonName =="History")
    {
        teacher.Scheduls.Add(schedules[i]);
    }
}

var pupil1 = new Pupil();
pupil1.Id = 1;
pupil1.Name = "Frederico Ambrella";
pupil1.Class = class1;

var pupil2 = new Pupil();
pupil2.Id = 2;
pupil2.Name = "Anna Brown";
pupil2.Class = class1;

var pupil3 = new Pupil();
pupil3.Id = 3;
pupil3.Name = "Pavel Miller";
pupil3.Class = class1;

var pupil4 = new Pupil();
pupil4.Id = 4;
pupil4.Name = "Oliver Johnson";
pupil4.Class = class1;

var pupil5 = new Pupil();
pupil5.Id = 5;
pupil5.Name = "Brenda Smith";
pupil5.Class = class1;

var pupils = new List<Pupil>
{
    pupil1, pupil2, pupil3, pupil4, pupil5
};
class1.Pupils = pupils;
class1.Schedules = schedules;

List<Schedule> lessonToday = pupil1.GetSchedulesForDay(Weekday.Tuesday);

var Lesson2Today = teacher.GetLessonForToday(Weekday.Monday,3);

for (int i = 0; i < lessonToday.Count; i++)
{
    Console.WriteLine(lessonToday[i].LessonName);
}
Console.WriteLine(Lesson2Today.LessonName);

for  (int i = 0; i < 10; i++)
{
    var lesson = new Schedule();
    lesson.Id = i + 10;
    lesson.LessonName = $"Lesson{i}";
    lesson.Day = (Weekday)(i % 5);
    lesson.Teacher = teacher;
    lesson.Class= class1;
    lesson.LessonNumber = i % 5;
     
    class1.AdSchedule(lesson);
}
pupil1.PupilNameAndClass();