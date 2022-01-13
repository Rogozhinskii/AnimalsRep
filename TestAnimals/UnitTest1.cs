using AnimalsLib;
using AnimalsLib.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAnimals
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FactoryTest()
        {
            //var factory = new AmphibiansFactory(20);

            //var ee = factory.CreateAnimal("орел","dsfads","dsfs");

            //var factory2 = new MammalsFactory(false);
            //var dd = factory2.CreateAnimal("lion", "dsfdsda", "sdfadsdfas");

            AnimalRepository<Birds> _birdsRep = new();

        }
    }
}