namespace Isu.Services
{
    public class Student
    {
        public Student(int id, string name, Group group)
        {
            Id = id;
            Name = name;
            Group = group;
        }

        public int Id { get; }
        public string Name { get; }
        public Group Group { get; private set; }

        public void ChangeGroup(Group group)
        {
            Group = group;
        }
    }
}