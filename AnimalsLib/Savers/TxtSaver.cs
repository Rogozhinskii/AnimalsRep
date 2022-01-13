using AnimalsLib.Interfaces;
using System.Text;

namespace AnimalsLib.Savers
{
    public class TxtSaver : ISaver
    {
        private string PrepareData(List<IAnimal> animals)
        {
            StringBuilder sb = new();
            foreach (var animal in animals){
                sb.AppendLine(animal.ToString());
            }
            return sb.ToString();
        }

        public void SaveData(string savePath, List<IAnimal> animals)
        {
            string txt=PrepareData(animals);
            File.WriteAllText($"{savePath}.txt", txt);            
        }
    }
}
