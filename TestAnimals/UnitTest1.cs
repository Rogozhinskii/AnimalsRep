using AnimalsLib;
using AnimalsLib.Repositories;
using AnimalsLib.Savers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAnimals
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FactoryTest()
        {
            var factory = new BirdsFactory(1.15);
            Birds ee = (Birds)factory.CreateAnimal("falcon", "dsfads", "dsfs");

            //var factory2 = new MammalsFactory(false);
            //var dd = factory2.CreateAnimal("lion", "dsfdsda", "sdfadsdfas");

            
            var rep=RepositoryFactory.GetRepository(AnimalType.Birds);
            rep.SaveMode = new XlsxSaver();
            rep.Add(ee);

            rep.Save(@"C:\Users\rogoz\OneDrive\Рабочий стол\Test\test");
            

        }

    }
}