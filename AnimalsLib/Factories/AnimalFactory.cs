namespace AnimalsLib
{
    public abstract class AnimalFactory : IAnimalFactory
    {
        public abstract IAnimal CreateAnimal(string type, string squad, string kind);
    }
}
