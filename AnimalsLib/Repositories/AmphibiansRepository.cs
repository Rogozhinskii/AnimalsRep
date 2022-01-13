using AnimalsLib.Interfaces;

namespace AnimalsLib.Repositories
{
    internal class AmphibiansRepository : AnimalRepository
    {
        public override void Add(IAnimal animal)
        {
            if (animal is Amphibians)
                Animals.Add(animal);
            else throw new InvalidCastException("Репозиторий только для амфибий");
        }

        public override void Remove(IAnimal animal)
        {
            if (animal is Amphibians)
                Animals.Add(animal);
            else throw new InvalidCastException("Репозиторий только для амфибий");
        }

    }
}
