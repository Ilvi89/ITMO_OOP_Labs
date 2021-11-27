namespace Banks.Entity.Clients
{
    public class Client
    {
        public Client(string id, string name, string surname, string passport)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Passport = passport;
        }

        public string Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Passport { get; }

        public static ClientBuilder Builder(string id, string name, string surname)
        {
            return new ClientBuilder().SetId(id).SetName(name).SetSurname(surname);
        }
    }
}