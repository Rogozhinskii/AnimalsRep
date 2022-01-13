using AnimalsLib.Interfaces;

namespace AnimalsLib.Repositories
{
    internal class MammalsRepository: AnimalRepository
    {
        public override void Add(IAnimal animal)
        {
            if (animal is Mammals)
                Animals.Add(animal);
            else throw new InvalidCastException("Репозиторий только для млекопитающих");
        }

        public override void Remove(IAnimal animal)
        {
            if (animal is Mammals)
                Animals.Remove(animal);
            else throw new InvalidCastException("Репозиторий только для млекопитающих");
        }

        protected override void FillRepository()
        {
            throw new NotImplementedException();
        }
    }
}
