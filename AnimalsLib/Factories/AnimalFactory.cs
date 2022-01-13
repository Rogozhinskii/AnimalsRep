using AnimalsLib.ConcreteAnimals;
using System.Reflection;

namespace AnimalsLib
{
    public class AnimalFactory : IAnimalFactory
    {
        private Type _typeOfCreationObject;
        public Dictionary<AnimalSquard, List<string>> AnimalTypesDictionary = new()
        {
            { AnimalSquard.Amphibians, new List<string>() { "turtle", "frog", "salamander" } },
            { AnimalSquard.Mammals, new List<string>() { "dog", "lion", "squirrel" } },
            { AnimalSquard.Birds, new List<string>() { "eagle", "owl", "falcon" } }
        };
        public IAnimal GetAnimal(AnimalSquard animalSquard, string concreteAnimalName, string family, string kind, bool isExtinct)
        {
            _typeOfCreationObject = GetTypeByObjectName(concreteAnimalName);
            if (_typeOfCreationObject == null) return new UnknownAnimal();
            if (!AnimalTypesDictionary[animalSquard].Contains(concreteAnimalName)) throw new ArgumentException($"{concreteAnimalName} не относится к {animalSquard}");            
            if (_typeOfCreationObject.IsAbstract) throw new MemberAccessException($"Не возможно создать объект {nameof(concreteAnimalName)}, т.к. он является абстрактным");
            return GetAnimal(family, kind, isExtinct);
        }

        private IAnimal GetAnimal(string family, string kind, bool isExtinct)
        {
            var constructor = _typeOfCreationObject.GetConstructor(new Type[] { typeof(string), typeof(string), typeof(bool) })
                ?? throw new NullReferenceException($"не найдет подходящий конструктов у типа или тип абстрактный");
            return (IAnimal)constructor.Invoke(new object[] { family, kind, isExtinct });
        }


        private Type GetTypeByObjectName(string concreteAnimalName) =>
                    Assembly.GetAssembly(GetType())
                            .GetTypes()
                            .FirstOrDefault(x => x.Name.Equals(concreteAnimalName, StringComparison.InvariantCultureIgnoreCase));

        
    }
}
