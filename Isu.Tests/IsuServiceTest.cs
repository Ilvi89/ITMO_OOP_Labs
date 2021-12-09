using Isu.Entity;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService(2);
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            _isuService.AddGroup("M3211");
            Group group1 = _isuService.FindGroup("M3211");
            Student student1 = _isuService.AddStudent(group1, "Ilya");

            Assert.AreEqual(student1.Group, group1);
            Assert.Contains(student1, _isuService.FindStudents(group1.FullName));
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                _isuService.AddGroup("M3211");
                Group group1 = _isuService.FindGroup("M3211");
                _isuService.AddStudent(group1, "Ilya");
                _isuService.AddStudent(group1, "Max");
                _isuService.AddStudent(group1, "Dan");
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                _isuService.AddGroup("M3211invalid");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group g1 = _isuService.AddGroup("M3211");
                Group g2 = _isuService.AddGroup("M3210");
                Student s1 = _isuService.AddStudent(g1, "Ilya");
                _isuService.ChangeStudentGroup(s1, g2);

                Assert.IsEmpty(_isuService.FindGroup(g1.FullName).Students);
                Assert.Contains(s1, _isuService.FindGroup(g2.FullName).Students);
                Assert.Contains(s1, g2.Students);
                
                _isuService.ChangeStudentGroup(s1, new Group(new GroupName("M3199"), 10));
            });
        }
    }
}