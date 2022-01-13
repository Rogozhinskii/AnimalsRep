namespace AnimalsLib
{
    public interface IAnimal
    {
        
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
