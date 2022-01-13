using AnimalsLib;
using AnimalsLib.Interfaces;
using AnimalsLib.Repositories;


namespace AnimalPlanet.Services
{
    public class ZooService
    {


        public IRepository GetRepository(AnimalType animalType)
        {            
            return RepositoryFactory.GetRepository(animalType);
        }

        private void FillRepository()
        {

        }
    }
}
