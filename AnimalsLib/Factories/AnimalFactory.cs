using AnimalsLib.ConcreteAnimals;
using AnimalsLib.Interfaces;
using System.Reflection;

namespace AnimalsLib
{
    public class AnimalFactory : IAnimalFactory
    {
        /// <summary>
        /// Хранилище в котором соотнесены виды животных и его представители
        /// </summary>
        private readonly ISquardsRepository<string> _squarsRepository;

        /// <summary>
        /// Тип создаваемого животного
        /// </summary>
        private Type _typeOfCreationObject;
        public AnimalFactory(ISquardsRepository<string> squarsRepository)
        {
            _squarsRepository = squarsRepository;            
        }
        public AnimalFactory() { }

        /// <summary>
        /// Возвращает экземпляр конкретного животного
        /// </summary>
        /// <param name="animalSquard"></param>
        /// <param name="concreteAnimalName"></param>
        /// <param name="family"></param>
        /// <param name="kind"></param>
        /// <param name="isExtinct"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="MemberAccessException"></exception>
        public IAnimal GetAnimal(AnimalSquard animalSquard, string concreteAnimalName, string family, string kind, bool isExtinct)
        {
            _typeOfCreationObject = GetTypeByObjectName(concreteAnimalName);
            if (_typeOfCreationObject == null) return new UnknownAnimal();
            if (!_squarsRepository.Squard[animalSquard].Contains(concreteAnimalName)) throw new ArgumentException($"{concreteAnimalName} не относится к {animalSquard}");            
            if (_typeOfCreationObject.IsAbstract) throw new MemberAccessException($"Не возможно создать объект {nameof(concreteAnimalName)}, т.к. он является абстрактным");
            return GetAnimal(family, kind, isExtinct);
        }

       
        public IAnimal GetAnimal(string concreteAnimalName, string family, string kind, bool isExtinct)
        {
            _typeOfCreationObject = GetTypeByObjectName(concreteAnimalName);
            if (_typeOfCreationObject == null) return new UnknownAnimal();
            return GetAnimal(family, kind, isExtinct);
        }

        /// <summary>
        /// Возвращает экземпляр конкретного животного
        /// </summary>
        /// <param name="family"></param>
        /// <param name="kind"></param>
        /// <param name="isExtinct"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        private IAnimal GetAnimal(string family, string kind, bool isExtinct)
        {
            var constructor = _typeOfCreationObject.GetConstructor(new Type[] { typeof(string), typeof(string), typeof(bool) })
                ?? throw new NullReferenceException($"не найдет подходящий конструктов у типа или тип абстрактный");
            var animal = (IAnimal)constructor.Invoke(new object[] { family, kind, isExtinct });
            animal.Id = Guid.NewGuid();
            return animal;
        }

        /// <summary>
        /// Возвращает тип создаваемого животного по его названию
        /// </summary>
        /// <param name="concreteAnimalName"></param>
        /// <returns></returns>
        private Type GetTypeByObjectName(string concreteAnimalName) =>
                    Assembly.GetAssembly(GetType())
                            .GetTypes()
                            .FirstOrDefault(x => x.Name.Equals(concreteAnimalName, StringComparison.InvariantCultureIgnoreCase));

        
    }
}
