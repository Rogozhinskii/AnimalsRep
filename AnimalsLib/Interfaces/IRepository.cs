namespace AnimalsLib.Interfaces
{
    public interface IRepository
    {
        ISaver SaveMode { get; set; }
        List<IAnimal> Animals { get; set; }
        void Add(IAnimal animal);
        void Remove(IAnimal animal);
        void Save(string savePath);

    }    
}
