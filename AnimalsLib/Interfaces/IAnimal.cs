namespace AnimalsLib
{
    public interface IAnimal
    {
        /// <summary>
        /// Тип животного
        /// </summary>
        public AnimalType AnimalType { get; }

        /// <summary>
        /// Отряд животного
        /// </summary>
        public string AnimalSquad { get;}
        /// <summary>
        /// Вид животного
        /// </summary>
        public string AnimalKind { get;}

    }
}
