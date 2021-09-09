using System.Text.RegularExpressions;
using Isu.Tools;

namespace Isu.Services
{
    public class Group
    {
        private const string Pattern = "M3[0-9]{3}";

        public Group(string name)
        {
            if (!Regex.IsMatch(name, Pattern)) throw new IsuException("invalid group name");
            CourseNumber = new CourseNumber(name.Substring(2, 1));
            GroupNumber = name.Substring(3, 2);
        }

        public CourseNumber CourseNumber { get; }
        public string Name => $"M3{CourseNumber}{GroupNumber}";
        private string GroupNumber { get; }
    }
}