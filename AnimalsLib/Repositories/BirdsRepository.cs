using AnimalsLib.Interfaces;

namespace AnimalsLib.Repositories
{
    internal class BirdsRepository : AnimalRepository
    {
        public override void Add(IAnimal animal)
        {
            if (animal is Birds)
                Animals.Add(animal);
            else throw new InvalidCastException("Репозиторий только для птиц");
        }

        public override void Remove(IAnimal animal)
        {
            if (animal is Birds)
                Animals.Remove(animal);
            else throw new InvalidCastException("Репозиторий только для птиц");
        }
        
    }
}
