using System;
using Isu.Entity;

namespace IsuExtra.Entity
{
    public class ExtraGroupName : GroupName
    {
        public ExtraGroupName(string name)
            : base(name)
        {
            MegaFacultyName = (MegaFacultyName)Enum.Parse(typeof(MegaFacultyName), name[0].ToString());
        }

        public MegaFacultyName MegaFacultyName { get; }
    }
}