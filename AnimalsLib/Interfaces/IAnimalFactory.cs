namespace AnimalsLib
{
    public interface IAnimalFactory
    {        
        public IAnimal CreateAnimal(string type, string squad, string kind);
    }
}
