using AnimalsLib.ConcreteAnimals;
using System.Reflection;

namespace AnimalsLib
{
    public class BirdsFactory : AnimalFactory
    {
        private readonly double _wingspan;

        public BirdsFactory(double wingspan)
        {
            _wingspan = wingspan;
        }

        /// <summary>
        /// Создает конкретного животного иерархии классов <see cref="BirdsFactory"/>   
        /// </summary>
        /// <param name="concreteAnimalName">общее название животного (собака, кот, лев и тд), для которого должен быть соответсвующий тип в иерархии
        /// </param>
        /// <param name="squad">отряд к которому животное относится</param>
        /// <param name="kind">вид животного</param>
        /// <returns></returns>
        /// <exception cref="MemberAccessException">исключение будет выбрашено при попытке создать экземпляр абстрактного класса</exception>
        /// <exception cref="NullReferenceException">исключение будет выбрашего при попытке вызова конструктора не удовлетворяющего параметрам
        /// базового конструктора абстрактного класса <see cref="BirdsFactory"/></exception>
        public override IAnimal CreateAnimal(string concreteAnimalName, string squad, string kind)
        {
            Type? animalType = Assembly.GetAssembly(GetType())
                                       .GetTypes()
                                       .FirstOrDefault(x => x.Name.Equals(concreteAnimalName, StringComparison.InvariantCultureIgnoreCase));
            if (animalType == null) return new UnknownAnimal();
            if (animalType.IsAbstract) throw new MemberAccessException($"Не возможно создать объект {nameof(concreteAnimalName)}, т.к. он является абстрактным");
            var constructor = animalType.GetConstructor(new Type[] { typeof(string), typeof(string), typeof(double) })
                ?? throw new NullReferenceException($"не найдет подходящий конструктов у типа или тип абстрактный");
            return (IAnimal)constructor.Invoke(new object[] { squad, kind, _wingspan });

        }
    }
}
