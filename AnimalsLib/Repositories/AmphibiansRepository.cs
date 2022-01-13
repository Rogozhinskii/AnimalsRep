using AnimalsLib.Data;
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

        protected override void FillRepository()
        {
            var factory=new AnimalFactory();
            for (int i = 0; i < 10; i++)
            {
                //Animals.Add(factory.GetAnimal(AnimalSquard.Amphibians,
                //                              RandomData.GetRandomAmfibianSquard(),
                //                              RandomData.GetRandomFamily(),
                //                              RandomData.GetRandomKinds(),
                //                              RandomData.))
            }
        }
    }
}
