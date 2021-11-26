namespace Banks.Entity.Memento
{
    // https://refactoring.guru/ru/design-patterns/memento
    public interface IMemento<out T>
    {
        public T GetState();
    }
}