namespace AnimalsLib
{
    public interface IAnimal
    {
        /// <summary>
        /// Название животного
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Отряд животного
        /// </summary>
        public AnimalSquard AnimalSquard { get; }

        /// <summary>
        /// Семейство животного
        /// </summary>
        public string AnimalFamily { get;}
        /// <summary>
        /// Вид животного
        /// </summary>
        public string AnimalKind { get;}

        /// <summary>
        /// Вымирает ли вид
        /// </summary>
        public bool IsExtinct { get;}

    }
}
