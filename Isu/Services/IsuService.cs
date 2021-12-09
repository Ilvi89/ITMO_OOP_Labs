using System.Collections.Generic;
using System.Text.RegularExpressions;
using Isu.Entity;
using Isu.Tools;
using Group = Isu.Entity.Group;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private readonly List<Group> _groups;
        private readonly List<Student> _students;
        private int _prevId;

        public IsuService(int defaultMaxStudentNumber)
        {
            DefaultMaxStudentNumber = defaultMaxStudentNumber;
            _prevId = 0;
            _groups = new List<Group>();
            _students = new List<Student>();
        }

        public int DefaultMaxStudentNumber { get; }

        public Group AddGroup(string name)
        {
            var group = new Group(new GroupName(name), DefaultMaxStudentNumber);
            _groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            Group curGroup = _groups.Find(g => g.Equals(group));
            if (curGroup == null) throw new IsuException("group not exist");
            var student = new Student(GenerateNextId(), name, curGroup);
            _students.Add(student);
            curGroup.AddStudent(student);
            return student;
        }

        public Student GetStudent(int id)
        {
            return _students.Find(s => s.Id == id);
        }

        public Student FindStudent(string name)
        {
            return _students.Find(s => s.Name == name);
        }

        public List<Student> FindStudents(string groupName)
        {
            Group group = _groups.Find(g => g.FullName == groupName);
            if (group == null) throw new IsuException("group name not exist");
            return group.Students;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            return _students.FindAll(s => s.Group.CourseNumber == courseNumber);
        }

        public Group FindGroup(string groupName)
        {
            return _groups.Find(g => g.FullName == groupName);
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
           return _groups.FindAll(g => g.CourseNumber == courseNumber);
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            Student oldStudent = _students.Find(s => s == student);
            if (oldStudent == null) throw new IsuException("student not exist");
            if (!_groups.Exists(g => g == newGroup)) throw new IsuException("group not exist");
            Group oldGroup = _groups.Find(g => g == student.Group);

            oldGroup?.RemoveStudent(student);
            newGroup.AddStudent(student);
            student.ChangeGroup(newGroup);
        }

        private int GenerateNextId()
        {
            _prevId++;
            return _prevId;
        }
    }
}