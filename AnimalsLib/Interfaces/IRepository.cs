namespace AnimalsLib.Interfaces
{
    public interface IRepository<T> where T : class, ITypedAnimal, new()
    {
        List<T> Animals { get; }
        void Add(T animal);
        void Remove(T animal);

    }
}
