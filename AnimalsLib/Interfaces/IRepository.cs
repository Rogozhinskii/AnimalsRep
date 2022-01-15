namespace AnimalsLib.Interfaces
{
    public interface IRepository<T>
    {        
        ISaver SaveMode { get; set; }
        List<T> Items { get; set; }
        void Add(T item);
        void Remove(T item);
        //void Update(T item);
        
        void SaveTo(string savePath);
        void Commit();

    }    
}
