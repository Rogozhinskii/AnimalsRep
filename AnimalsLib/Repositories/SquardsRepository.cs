using AnimalsLib.Interfaces;
using Newtonsoft.Json;

namespace AnimalsLib.Repositories
{
    public class SquardsRepository : ISquardsRepository<string>
    {
        private string filePath = $"..\\..\\..\\..\\AnimalsLib\\Repositories\\Data\\Squards.json";
        public SquardsRepository()
        {
            Squard = new();
            Load();
        }

        private void Load()
        {
            var json=File.ReadAllText(filePath);
            Squard = JsonConvert.DeserializeObject<Dictionary<AnimalSquard, List<string>>>(json);
        }

        public bool AutoFill { get; set; }=false;
        public ISaver SaveMode { get; set; }
        public List<string> Items { get; set; }

        
        public Dictionary<AnimalSquard, List<string>> Squard { get;private set; }

        public void Add(string item)
        {
            throw new NotImplementedException();
        }

        public void Remove(string item)
        {
            throw new NotImplementedException();
        }
        
        public void SaveTo(string savePath)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            string json = JsonConvert.SerializeObject(Squard);
            File.WriteAllText(filePath, json);
        }

        public void Update(string item)
        {
            throw new NotImplementedException();
        }
    }
}
