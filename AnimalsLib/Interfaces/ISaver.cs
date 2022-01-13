namespace AnimalsLib.Interfaces
{
    public interface ISaver
    {
        void SaveData(string savePath,List<IAnimal> animals);
    }
}
