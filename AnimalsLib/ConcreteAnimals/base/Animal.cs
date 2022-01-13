namespace AnimalsLib
{
    public abstract class Animal : IAnimal
    {        
        
        public string AnimalSquad { get; }
        public string AnimalKind { get; }

        public Animal(string squad,string kind)
        {                       
            if(string.IsNullOrEmpty(squad)) throw new ArgumentNullException(nameof(squad));
            if(string.IsNullOrEmpty(kind)) throw new ArgumentNullException(nameof(kind));
                                    
            AnimalSquad = squad;
            AnimalKind = kind;
        }


    }
}
