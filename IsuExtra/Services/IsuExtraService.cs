using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Services;
using Isu.Tools;
using IsuExtra.Entity;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class IsuExtraService : IIsuExtraService
    {
        private readonly IIsuService _iIsuService;
        private readonly List<ExtraGroup> _listOfGroups;
        private readonly List<Lesson> _listOfLessons;
        private readonly List<MegaFaculty> _listOfMegaFaculty;

        public IsuExtraService()
        {
            _listOfGroups = new List<ExtraGroup>();
            _listOfMegaFaculty = new List<MegaFaculty>();
            _listOfLessons = new List<Lesson>();
            _iIsuService = new IsuService(10);
        }

        public Lesson AddLesson(string lessonName, DateTime startTime, DateTime endTime, string teacher, int classRoom, int dayOfWeek)
        {
            if (_listOfLessons.Contains(GetLesson(lessonName, startTime, endTime, teacher, classRoom, dayOfWeek)))
                throw new IsuExtraException("lesson already exists");

            var lesson = new Lesson(lessonName, startTime, endTime, teacher, classRoom, dayOfWeek);
            _listOfLessons.Add(lesson);
            return lesson;
        }

        public Lesson AddLessonToGroup(Lesson lesson, ExtraGroup group)
        {
            if (group.GroupLessons.Contains(lesson)) throw new IsuExtraException("group already has lesson");

            group.GroupLessons.Add(lesson);
            return lesson;
        }

        public Lesson AddLessonToGroup(Lesson lesson, OgnpGroup group)
        {
            if (group.Lessons.Contains(lesson)) throw new IsuExtraException("group already has lesson");

            group.Lessons.Add(lesson);
            return lesson;
        }

        public Lesson GetLesson(string lessonName, DateTime startTime, DateTime endTime, string teacher, int classRoom, int dayOfWeek)
        {
            return _listOfLessons.FirstOrDefault(t =>
                t.LessonName == lessonName && t.StartTime == startTime && t.EndTime == endTime &&
                t.Teacher == teacher && t.Teacher == teacher && t.DayOfWeek == dayOfWeek);
        }

        public MegaFaculty AddMegaFaculty(MegaFacultyName megaFacultyName, string ognpName)
        {
            if (_listOfMegaFaculty.Find(faculty => faculty.MegaFacultyName == megaFacultyName) == null)
            {
                var faculty = new MegaFaculty(megaFacultyName, ognpName);
                _listOfMegaFaculty.Add(faculty);
                return faculty;
            }

            throw new IsuException("faculty already exist");
        }

        public MegaFaculty GetMegaFaculty(MegaFacultyName name)
        {
            foreach (MegaFaculty t in _listOfMegaFaculty.Where(t => t.MegaFacultyName == name)) return t;

            throw new IsuExtraException("there is no such faculty\n");
        }

        public OgnpGroup AddOgnpThread(MegaFaculty megaFaculty, string ognpName, int maxStudentsOnThread)
        {
            if (megaFaculty.ListOfOgnpGroups.Find(ognp => ognp.OgnpThreadName == ognpName) == null)
            {
                var newOgnp = new OgnpGroup(ognpName, megaFaculty, maxStudentsOnThread);
                megaFaculty.ListOfOgnpGroups.Add(newOgnp);
                return newOgnp;
            }

            throw new IsuExtraException("there is a thread with the same name");
        }

        public void AddOgnpToStudent(ExtraStudent student, OgnpGroup ognpName)
        {
            if (student.OgnpGroups.Any(
                t => student.OgnpGroups.Any(n => n.MegaFacultyName == ognpName.MegaFacultyName)))
                throw new IsuExtraException("student can't be on more than 1 ognp thread from the same faculty\n");

            if (student.OgnpGroups.Count >= 2) throw new IsuExtraException("student can't have more than 2 ognp\n");

            if (student.OgnpGroups.Contains(ognpName)) throw new IsuExtraException("student is already on this ognp");

            if (student.MegaFacultyName == ognpName.MegaFacultyName)
                throw new IsuExtraException("student can't get ognp of the same faculty he is study at");

            if (ognpName.MaxStudentsOnThread > ognpName.ListOfStudentsOnThread.Count)
            {
                student.OgnpGroups.Add(ognpName);
                ognpName.ListOfStudentsOnThread.Add(student);
            }
        }

        public void CloseOgnpCourse(ExtraStudent student, OgnpGroup group)
        {
            foreach (OgnpGroup ognp in student.OgnpGroups.Where(ognp => ognp == group))
                student.OgnpGroups.Remove(group);

            foreach (OgnpGroup ognp in _listOfMegaFaculty.SelectMany(faculty =>
                faculty.ListOfOgnpGroups.Where(ognp => ognp == group)))
                ognp.ListOfStudentsOnThread.Remove(student);
        }

        public void CloseAllOgnpCourse(ExtraStudent student)
        {
            student.OgnpGroups.Clear();
            foreach (OgnpGroup ognp in _listOfMegaFaculty.SelectMany(faculty => faculty.ListOfOgnpGroups))
            {
                foreach (ExtraStudent stud in ognp.ListOfStudentsOnThread.Where(stud => stud == student))
                    ognp.ListOfStudentsOnThread.Remove(student);
            }
        }

        public List<OgnpGroup> GetOgnpThreadsOnMegaFaculty(MegaFaculty megaFaculty)
        {
            if (megaFaculty.ListOfOgnpGroups != null) return megaFaculty.ListOfOgnpGroups;

            throw new IsuExtraException("no such MegaFaculty\n");
        }

        public List<ExtraStudent> GetOgnpThreadStudents(MegaFaculty megaFaculty, OgnpGroup group)
        {
            foreach (OgnpGroup ognp in
                megaFaculty.ListOfOgnpGroups.Where(ognp => ognp.OgnpThreadName == group.OgnpThreadName))
                return ognp.ListOfStudentsOnThread;

            throw new IsuExtraException("no such MegaFaculty or ognp\n");
        }

        public OgnpGroup GetOgnp(MegaFaculty megaFaculty, string ognpName)
        {
            foreach (OgnpGroup ognp in megaFaculty.ListOfOgnpGroups.Where(ognp => ognp.OgnpThreadName == ognpName))
                return ognp;

            throw new IsuExtraException("no such ognp\n");
        }

        public List<ExtraStudent> GetStudentsWithoutOgnp(ExtraGroup group)
        {
            var answer = new List<ExtraStudent>();
            foreach (ExtraGroup g in _listOfGroups.Where(g => g == group))
                answer.AddRange(g.ListOfGroup.Where(student => student.OgnpGroups.Count == 0));

            return answer;
        }

        // isu service functions
        public ExtraGroup AddGroup(ExtraGroupName name, int maxOfStudentsInGroup)
        {
            if (_listOfGroups.Find(group => group.Name == name) == null)
            {
                var group = new ExtraGroup(name, maxOfStudentsInGroup);
                _listOfGroups.Add(group);
                return group;
            }

            throw new IsuExtraException("There is a group with the same name");
        }

        public ExtraStudent AddStudent(ExtraGroup group, string name, int id)
        {
            if (group.ListOfGroup.Count > group.MaxStudentNumber) throw new IsuException("group is overflowed");

            ExtraStudent student = FindStudent(name);
            if (student == null)
            {
                student = new ExtraStudent(name, group, id);
                group.ListOfGroup.Add(student);
            }
            else
            {
                if (student.Group == group)
                    throw new IsuException("student is added to this group already");
                throw new IsuException("student is added to another group");
            }

            return student;
        }

        public ExtraStudent FindStudent(string name)
        {
            return _listOfGroups.SelectMany(t => t.ListOfGroup.Where(t1 => t1.Name == name)).FirstOrDefault();
        }

        public ExtraGroup GetGroup(ExtraGroupName groupName)
        {
            return _listOfMegaFaculty
                .SelectMany(faculty => faculty.ListOfMegaFacultyGroups.Where(group => group.Name == groupName))
                .FirstOrDefault();
        }
    }
}