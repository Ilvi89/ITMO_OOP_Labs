using System.Collections.Generic;
using Isu.Entity;

namespace IsuExtra.Entity
{
    public class ExtraGroup : Group
    {
        public ExtraGroup(ExtraGroupName groupName, int maxOfStudentsInGroup)
            : base(groupName, maxOfStudentsInGroup)
        {
            GroupLessons = new List<Lesson>();
            MegaFaculty = groupName.MegaFacultyName;
            ListOfGroup = new List<ExtraStudent>();
        }

        public MegaFacultyName MegaFaculty
        {
            get;
        }

        public List<Lesson> GroupLessons
        {
            get;
        }

        public List<ExtraStudent> ListOfGroup
        {
            get;
        }
    }
}