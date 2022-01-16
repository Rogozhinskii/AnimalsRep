namespace AnimalsLib.Factories
{
    public interface ISquardFactory
    {
        /// <summary>
        /// Возвращает список животных соответсвующего отряда
        /// </summary>
        /// <param name="squard"></param>
        /// <returns></returns>
        public List<IAnimal> GetAnimalsBySquard(AnimalSquard squard);
    }
}