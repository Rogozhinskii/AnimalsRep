namespace AnimalsLib.Factories
{
    public interface ISquardFactory
    {
        public List<IAnimal> GetAnimalsBySquard(AnimalSquard squard);
    }
}