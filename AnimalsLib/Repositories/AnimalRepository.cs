using AnimalsLib.Interfaces;

namespace AnimalsLib.Repositories
{
    internal abstract class AnimalRepository : IRepository
    {
        public ISaver SaveMode { get; set; }
        public List<IAnimal> Animals { get; set; }
        public bool AutoFill { get; set; }

        public AnimalRepository(){
            if (!AutoFill)
                Animals = new List<IAnimal>();            
            else
                FillRepository();
        }
        public virtual void Add(IAnimal animal)=>
            Animals.Add(animal);

        public virtual void Remove(IAnimal animal)=>
            Animals.Remove(animal);

        public virtual void Save(string savePath)=>
            SaveMode.SaveData(savePath, Animals);

        protected abstract void FillRepository();
        
    }
}
