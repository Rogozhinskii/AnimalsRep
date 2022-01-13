namespace AnimalsLib
{
    public abstract class Animal : IAnimal
    {        
        
        public string AnimalSquad { get; }
        public string AnimalKind { get; }
        public AnimalType AnimalType { get; }

        public Animal(AnimalType type, string squad,string kind)
        {                       
            if(string.IsNullOrEmpty(squad)) throw new ArgumentNullException(nameof(squad));
            if(string.IsNullOrEmpty(kind)) throw new ArgumentNullException(nameof(kind));
            AnimalType = type;
            AnimalSquad = squad;
            AnimalKind = kind;
        }

        public override string ToString() =>
            $"AnimalType:{AnimalType};AnimalSquad:{AnimalSquad};AnimalKind:{AnimalKind};";

    }
}
