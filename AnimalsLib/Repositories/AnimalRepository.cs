using AnimalsLib.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace AnimalsLib.Repositories
{
    public class AnimalRepository : IRepository<IAnimal>
    {
        protected virtual string FilePath { get; }
        public ISaver SaveMode { get; set; }
        public List<IAnimal> Items { get; set; }       

        public AnimalRepository(){
            FilePath = $"..\\..\\..\\..\\AnimalsLib\\Repositories\\Data\\AnimalRepository.json";
            Items = new List<IAnimal>();
            LoadItems();
        }

        void LoadItems()
        {
            string json=File.ReadAllText(FilePath);
            AnimalFactory factory = new();
            foreach(var item in JArray.Parse(json))
            {
                var animal = factory.GetAnimal(item["Name"].ToString(),
                                               item["AnimalFamily"].ToString(),
                                               item["AnimalKind"].ToString(),
                                               Convert.ToBoolean(item["IsExtinct"].ToString()));
                animal.Id = new Guid(item["Id"].ToString());
                Add(animal);
            }
            
        }

        public void Add(IAnimal animal)=>
            Items.Add(animal);       

        public void Remove(IAnimal animal)=>
            Items.Remove(animal);        

        public virtual void SaveTo(string savePath)=>
            SaveMode.SaveData(savePath, Items);
                
        public void Commit()
        {
            JsonSerializerSettings settings = new()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            settings.Converters.Add(new StringEnumConverter());
            string json=JsonConvert.SerializeObject(Items,settings);
            File.WriteAllText(FilePath, json);
        }

        
    }
}
