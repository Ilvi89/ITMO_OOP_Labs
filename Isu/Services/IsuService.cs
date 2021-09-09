using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private readonly List<Group> _groups;
        private readonly List<Student> _students;

        public IsuService()
        {
            _groups = new List<Group>();
            _students = new List<Student>();
        }

        public Group AddGroup(string name)
        {
            var newGroup = new Group(name);
            _groups.Add(newGroup);
            return newGroup;
        }

        public Student AddStudent(Group group, string name)
        {
            var newStudent = new Student(name, group);
            _students.Add(newStudent);
            return newStudent;
        }

        public Student GetStudent(int id)
        {
            return _students.Find(student => student.Id == id);
        }

        public Student FindStudent(string name)
        {
            return _students.Find(student => student.Name == name);
        }

        public List<Student> FindStudents(string groupName)
        {
            return _students.FindAll(student => student.Group.Name == groupName);
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            return _students.FindAll(student => student.Group.CourseNumber == courseNumber);
        }

        public Group FindGroup(string groupName)
        {
            return _groups.Find(group => group.Name == groupName);
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return _groups.FindAll(group => group.CourseNumber == courseNumber);
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            if (FindGroup(newGroup.Name) == null) throw new IsuException("group not found");
            Student oldStudent = _students.Find(s => s.Id == student.Id);
            if (oldStudent == null) throw new IsuException("student not found");
            oldStudent.ChangeGroup(newGroup);
        }
    }
}