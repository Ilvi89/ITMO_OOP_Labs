using System.Collections.Generic;

namespace Shops.Repo.RepoImpl
{
    public class BaseRepo<T>
        where T : Entity.Entity
    {
        protected List<T> Store { get; } = new ();

        public T Save(T entity)
        {
            Store.Add(entity);
            return entity;
        }

        public T GetById(string id)
        {
            return Store.Find(o => Equals(o.Id, id));
        }

        public T Update(T entity)
        {
            Store[Store.IndexOf(Store.Find(e => e.Id.Equals(entity.Id)))] = entity;
            return entity;
        }
    }
}