using AnimalsLib.Interfaces;

namespace AnimalsLib.Repositories
{
    public class AnimalRepository<T> : IRepository<T> where T : class,ITypedAnimal, new()
    {
        private List<T> _animals;
        public List<T> Animals => _animals;

        public AnimalRepository()
        {
            _animals = new List<T>();
        }

        public AnimalRepository(IEnumerable<T> items)
            :this()
        {
            _animals.AddRange(items);
        }

        public void Add(T animal)=>
            _animals.Add(animal);

        public void Remove(T animal)=>
            _animals.Remove(animal);
    }
}
