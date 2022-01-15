using AnimalsLib.Interfaces;
using System.Text;

namespace AnimalsLib.Savers
{
    /// <summary>
    ///Выполняет сохраение в текстовый формат 
    /// </summary>
    public class TxtSaver : ISaver
    {
        /// <summary>
        /// Преобразует коллекцию объектов с строковое представление
        /// </summary>
        /// <param name="animals"></param>
        /// <returns></returns>
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
