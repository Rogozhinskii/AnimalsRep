namespace AnimalsLib.Interfaces
{
    public interface IRepository
    {
        public bool AutoFill { get; set; }
        ISaver SaveMode { get; set; }
        List<IAnimal> Animals { get; set; }
        void Add(IAnimal animal);
        void Remove(IAnimal animal);
        void Save(string savePath);

    }    
}
