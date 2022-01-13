namespace AnimalsLib.ConcreteAnimals
{
    internal class UnknownAnimal : Animal
    {
        public UnknownAnimal(AnimalType type=AnimalType.Unknown, 
                       string squad="не понятный", 
                       string kind="не определен") : base(type, squad, kind)
        {
        }
    }
}
