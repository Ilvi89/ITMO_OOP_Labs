using System.Collections.Generic;
using IsuExtra.Tools;

namespace IsuExtra.Entity
{
    public class MegaFaculty
    {
        public MegaFaculty(MegaFacultyName megaFacultyName, string ognpName)
        {
            ListOfMegaFacultyGroups = new List<ExtraGroup>();
            ListOfOgnpGroups = new List<OgnpGroup>();
            MegaFacultyName = megaFacultyName;
            OgnpName = ognpName;
        }

        public List<ExtraGroup> ListOfMegaFacultyGroups { get; }

        public List<OgnpGroup> ListOfOgnpGroups { get; }

        public MegaFacultyName MegaFacultyName { get; }

        public string OgnpName { get; }

        public void AddOgnp(OgnpGroup ognpGroup)
        {
            if (ListOfOgnpGroups.Count > 1) throw new IsuExtraException("adadad");
            ListOfOgnpGroups.Add(ognpGroup);
        }
    }
}