using System.Collections.Generic;
using Isu.Entity;

namespace IsuExtra.Entity
{
    public class ExtraStudent : Student
    {
        public ExtraStudent(string name, ExtraGroup group, int id)
            : base(id, name, group)
        {
            OgnpGroups = new List<OgnpGroup>();
            MegaFacultyName = group.MegaFaculty;
        }

        public List<OgnpGroup> OgnpGroups { get; }

        public MegaFacultyName MegaFacultyName { get; }
    }
}