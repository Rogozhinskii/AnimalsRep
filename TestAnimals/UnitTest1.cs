using AnimalsLib;
using AnimalsLib.Data;
using AnimalsLib.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestAnimals
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FactoryTest()
        {

            var squardRepository = new SquardsRepository();
            var factory = new AnimalFactory(squardRepository);
            var rep = new AnimalRepository();

            //AnimalSquardFactory squardFactory = new(rep);
            //var tt=squardFactory.GetAnimalBySquard(AnimalSquard.Amphibians);
            //rep.Commit();


            var animals = new List<IAnimal>();

            for (int i = 0; i < 10; i++)
            {
                animals.Add(factory.GetAnimal(RandomData.GetRandomBirdsSquard(), RandomData.GetRandomFamily(), RandomData.GetRandomKinds(), RandomData.GetRandomExtinct()));
                animals.Add(factory.GetAnimal(RandomData.GetRandomAmfibianSquard(), RandomData.GetRandomFamily(), RandomData.GetRandomKinds(), RandomData.GetRandomExtinct()));
                animals.Add(factory.GetAnimal(RandomData.GetRandomMammalsSquard(), RandomData.GetRandomFamily(), RandomData.GetRandomKinds(), RandomData.GetRandomExtinct()));
            }
            rep.Items.AddRange(animals);
            rep.Commit();


        }

    }
}