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
           var factory=new AnimalFactory();
            var ee = factory.GetAnimal(AnimalSquard.Amphibians, "frog", "dsfsfdsds","sdfsddsf", false);

            //var factory2 = new MammalsFactory(false);
            //var dd = factory2.CreateAnimal("lion", "dsfdsda", "sdfadsdfas");

            
            var rep=RepositoryFactory.GetRepository(AnimalSquard.Birds);
            rep.SaveMode = new XlsxSaver();
            rep.Add(ee);

            rep.Save(@"C:\Users\rogoz\OneDrive\Рабочий стол\Test\test");
            

        }

    }
}