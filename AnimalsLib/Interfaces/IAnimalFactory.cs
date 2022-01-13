namespace AnimalsLib
{
    public interface IAnimalFactory
    {
        public IAnimal GetAnimal(AnimalSquard squad, string concreteAnimalName, string family, string kind, bool isExtinct);
    }
}
