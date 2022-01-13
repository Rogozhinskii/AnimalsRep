using AnimalsLib.Interfaces;

namespace AnimalsLib.Repositories
{
    internal class BirdsRepository : AnimalRepository
    {
        public override void Add(IAnimal animal)
        {           
            Animals.Add(animal);           
        }

        public override void Remove(IAnimal animal)
        {
            if (animal is Birds)
                Animals.Remove(animal);
            else throw new InvalidCastException("Репозиторий только для птиц");
        }

        protected override void FillRepository()
        {
            throw new NotImplementedException();
        }
    }
}
