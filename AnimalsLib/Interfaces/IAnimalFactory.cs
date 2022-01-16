namespace AnimalsLib
{
    public interface IAnimalFactory
    {
        /// <summary>
        /// Создает конкретного животного 
        /// </summary>
        /// <param name="squad">к какому отряду относится животное</param>
        /// <param name="concreteAnimalName">название животного</param>
        /// <param name="family">к какому семейству его отнести</param>
        /// <param name="kind">к какому виду его отнести</param>
        /// <param name="isExtinct">вымирает ли вид</param>
        /// <returns></returns>
        public IAnimal GetAnimal(AnimalSquard squad, string concreteAnimalName, string family, string kind, bool isExtinct);


        /// <summary>
        /// Создает конкретного животного 
        /// </summary>        
        /// <param name="concreteAnimalName">название животного</param>
        /// <param name="family">к какому семейству его отнести</param>
        /// <param name="kind">к какому виду его отнести</param>
        /// <param name="isExtinct">вымирает ли вид</param>
        /// <returns></returns>
        public IAnimal GetAnimal(string concreteAnimalName, string family, string kind, bool isExtinct);
    }
}
