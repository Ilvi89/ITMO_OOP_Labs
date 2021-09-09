namespace Isu.Services
{
    public class Student
    {
        private static int _nextId;

        public Student(string name, Group group)
        {
            Id = _nextId;
            _nextId++;
            Name = name;
            Group = group;
        }

        public int Id { get; }
        public string Name { get; }
        public Group Group { get; private set; }

        public void ChangeGroup(Group newGroup)
        {
            Group = newGroup;
        }
    }
}