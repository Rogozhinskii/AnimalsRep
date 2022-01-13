using AnimalsLib.Interfaces;

namespace AnimalsLib.Repositories
{
    public class RepositoryFactory
    {



        public static IRepository GetRepository(AnimalType type)
        {
            return type switch
            {
                AnimalType.Birds => new BirdsRepository(),
                AnimalType.Amphibians => new AmphibiansRepository(),
                AnimalType.Mammals => new MammalsRepository(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
