namespace AnimalsLib
{
    public interface IAnimal
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Название животного
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Отряд животного
        /// </summary>
        public AnimalSquard AnimalSquard { get; set; }

        /// <summary>
        /// Семейство животного
        /// </summary>
        public string AnimalFamily { get; set; }
        /// <summary>
        /// Вид животного
        /// </summary>
        public string AnimalKind { get; set; }

        /// <summary>
        /// Вымирает ли вид
        /// </summary>
        public bool IsExtinct { get; set; }

    }
}
