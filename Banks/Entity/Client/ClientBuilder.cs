﻿namespace Banks.Entity.Client
{
    public class ClientBuilder
    {
        private string _id;
        private string _name;
        private string _surname;

        public ClientBuilder SetId(string id)
        {
            _id = id;
            return this;
        }

        public ClientBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ClientBuilder SetSurname(string surname)
        {
            _surname = surname;
            return this;
        }

        public Entity.Client.Client GetClient()
        {
            return new Entity.Client.Client(_id, _name, _surname);
        }
    }
}