using System;
using System.Linq;
using Isu.Tools;

namespace Isu.Entity
{
    public class GroupName
    {
        private string _name;

        public GroupName(string name)
        {
            // Todo: refactor this (reg exp)
            string groupNumber = name[3] + name[4].ToString();
            if (name.Length == 5 &&
                name[0] == 'M' &&
                name[1] == '3' &&
                Enumerable.Range(1, 6).Contains(int.Parse(name[2].ToString())) &&
                Enumerable.Range(0, 99).Contains(int.Parse(groupNumber)))
            {
                _name = name;
                GroupNumber = groupNumber;
                CourseNumber = new CourseNumber(name[2].ToString());
            }
            else
            {
                throw new IsuException("invalid name of group");
            }
        }

        public CourseNumber CourseNumber
        {
            get;
        }

        public string GroupNumber
        {
            get;
        }
    }
}