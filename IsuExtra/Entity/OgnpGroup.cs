using System.Collections.Generic;

namespace IsuExtra.Entity
{
    public class OgnpGroup
    {
        public OgnpGroup(string ognpThreadName, MegaFaculty megaFaculty, int maxStudentsOnThread)
        {
            OgnpName = megaFaculty.OgnpName;
            OgnpThreadName = ognpThreadName;
            MegaFacultyName = megaFaculty.MegaFacultyName;
            MaxStudentsOnThread = maxStudentsOnThread;
            Lessons = new List<Lesson>();
            ListOfStudentsOnThread = new List<ExtraStudent>();
        }

        public string OgnpThreadName
        {
            get;
        }

        public string OgnpName { get; }

        public List<ExtraStudent> ListOfStudentsOnThread { get; }

        public List<Lesson> Lessons { get; }

        public MegaFacultyName MegaFacultyName { get; }

        public int MaxStudentsOnThread { get; }
    }
}