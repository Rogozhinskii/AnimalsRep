using AnimalsLib;
using AnimalsLib.Interfaces;
using AnimalsLib.Repositories;


namespace AnimalPlanet.Services
{
    public class ZooService
    {


        public IRepository GetRepository(AnimalSquard animalSquard)
        {            
            return RepositoryFactory.GetRepository(animalSquard);
        }

        private void FillRepository()
        {

        }
    }
}
