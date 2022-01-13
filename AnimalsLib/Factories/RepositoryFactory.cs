using AnimalsLib.Interfaces;

namespace AnimalsLib.Repositories
{
    public class RepositoryFactory
    {

        public static IRepository GetRepository(AnimalSquard squard)
        {
            return squard switch
            {
                AnimalSquard.Birds => new BirdsRepository(),
                AnimalSquard.Amphibians => new AmphibiansRepository(),
                AnimalSquard.Mammals => new MammalsRepository(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
