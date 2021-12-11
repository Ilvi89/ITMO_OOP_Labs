using System;

namespace IsuExtra.Entity
{
    public class Lesson
    {
        public Lesson(
            string lessonName, DateTime startTime, DateTime endTime, string teacher, int classRoom, int dayOfWeek)
        {
            LessonName = lessonName;
            StartTime = startTime;
            EndTime = endTime;
            Teacher = teacher;
            DayOfWeek = dayOfWeek;
        }

        public string LessonName { get; }

        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public string Teacher { get; }

        public int DayOfWeek { get; }
    }
}