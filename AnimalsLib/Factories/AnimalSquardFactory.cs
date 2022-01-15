using AnimalsLib.Interfaces;

namespace AnimalsLib.Factories
{
    public class AnimalSquardFactory:ISquardFactory
    {
        private readonly IRepository<IAnimal> _repository;

        public AnimalSquardFactory(IRepository<IAnimal> repository)
        {
            _repository = repository;
        }

        public List<IAnimal> GetAnimalsBySquard(AnimalSquard squard)
        {
            return squard switch
            {
                AnimalSquard.Amphibians => _repository.Items.Where(x => x.AnimalSquard==AnimalSquard.Amphibians).ToList(),
                AnimalSquard.Birds => _repository.Items.Where(x => x.AnimalSquard == AnimalSquard.Birds).ToList(),
                AnimalSquard.Mammals => _repository.Items.Where(x => x.AnimalSquard == AnimalSquard.Mammals).ToList(),
                AnimalSquard.Unknown=>_repository.Items.Where(x => x.AnimalSquard== AnimalSquard.Unknown).ToList(),
                _ => new List<IAnimal>()
            };
        }
    }
}
