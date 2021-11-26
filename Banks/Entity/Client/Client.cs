namespace Banks.Entity.Client
{
    public class Client
    {
        public Client(string id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public string Id { get; }
        public string Name { get; }
        public string Surname { get; }

        public static ClientBuilder Builder(string id, string name, string surname)
        {
            return new ClientBuilder().SetId(id).SetName(name).SetSurname(surname);
        }
    }
}