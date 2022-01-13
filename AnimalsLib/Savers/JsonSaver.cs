using AnimalsLib.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AnimalsLib.Savers
{
    public class JsonSaver : ISaver
    {
        private string SerializeData(List<IAnimal> animals)
        {
            JsonSerializerSettings settings = new()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            settings.Converters.Add(new StringEnumConverter());
            return JsonConvert.SerializeObject(animals, settings);
        }
            
        
        public void SaveData(string savePath,List<IAnimal> animals)
        {
            string json=SerializeData(animals);
            File.WriteAllText($"{savePath}.json",json);
        }
    }
}
