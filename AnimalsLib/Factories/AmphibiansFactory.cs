using AnimalsLib.ConcreteAnimals;
using System.Reflection;

namespace AnimalsLib
{
    public class AmphibiansFactory : AnimalFactory
    {
        public int MaxImmersionDepth { get; set; }

        public AmphibiansFactory(int maxImmersionDepth)
        {
            MaxImmersionDepth = maxImmersionDepth;
        }

        /// <summary>
        /// Создает конкретного животного иерархии классов <see cref="Amphibians"/>   
        /// </summary>
        /// <param name="concreteAnimalName">общее название животного (собака, кот, лев и тд), для которого должен быть соответсвующий тип в иерархии
        /// </param>
        /// <param name="squad">отряд к которому животное относится</param>
        /// <param name="kind">вид животного</param>
        /// <returns></returns>
        /// <exception cref="MemberAccessException">исключение будет выбрашено при попытке создать экземпляр абстрактного класса</exception>
        /// <exception cref="NullReferenceException">исключение будет выбрашего при попытке вызова конструктора не удовлетворяющего параметрам
        /// базового конструктора абстрактного класса <see cref="Amphibians"/></exception>
        public override IAnimal CreateAnimal(string concreteAnimalName, string squad, string kind)
        {   
            Type? animalType = Assembly.GetAssembly(GetType())
                                       .GetTypes()
                                       .FirstOrDefault(x => x.Name.Equals(concreteAnimalName, StringComparison.InvariantCultureIgnoreCase));
            if (animalType == null) return new UnknownAnimal();
            if (animalType.IsAbstract) throw new MemberAccessException($"Не возможно создать объект {nameof(concreteAnimalName)}, т.к. он является абстрактным");
            var constructor = animalType.GetConstructor(new Type[] { typeof(string), typeof(string), typeof(int) })
                ?? throw new NullReferenceException($"не найдет подходящий конструктов у типа или тип абстрактный");
            return (IAnimal)constructor.Invoke(new object[] { squad, kind, MaxImmersionDepth });

        }

    }
}
