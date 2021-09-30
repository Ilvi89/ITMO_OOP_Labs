using Isu.Tools;

namespace Isu.Services
{
    public class CourseNumber
    {
        private readonly int _number;

        public CourseNumber(int number)
        {
            if (number is < 1 or > 4) throw new IsuException("invalid course number");
            _number = number;
        }

        public CourseNumber(string number)
        {
            _number = int.Parse(number);
        }

        public override string ToString()
        {
            return _number.ToString();
        }
    }
}