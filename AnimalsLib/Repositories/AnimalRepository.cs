using AnimalsLib.Interfaces;

namespace AnimalsLib.Repositories
{
    internal class AnimalRepository : IRepository
    {
        public ISaver SaveMode { get; set; }
        public List<IAnimal> Animals { get; set; }

        public AnimalRepository(){
            Animals = new List<IAnimal>();
        }
        public virtual void Add(IAnimal animal)=>
            Animals.Add(animal);

        public virtual void Remove(IAnimal animal)=>
            Animals.Remove(animal);

        public virtual void Save(string savePath)=>
            SaveMode.SaveData(savePath, Animals);
        
    }
}
