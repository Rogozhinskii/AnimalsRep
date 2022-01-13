namespace AnimalsLib
{
    public abstract class Animal : IAnimal
    {        
        
        public string AnimalFamily { get; }
        public string AnimalKind { get; }
        public AnimalSquard AnimalSquard { get; }

        public bool IsExtinct { get; }

        public string Name => GetType().Name;

        public Animal(AnimalSquard squard, string family,string kind,bool isExtinct)
        {                       
            if(string.IsNullOrEmpty(family)) throw new ArgumentNullException(nameof(family));
            if(string.IsNullOrEmpty(kind)) throw new ArgumentNullException(nameof(kind));
            AnimalSquard = squard;
            AnimalFamily = family;
            AnimalKind = kind;
            IsExtinct = isExtinct;
        }

        public override string ToString() =>
            $"AnimalType:{AnimalSquard};AnimalSquad:{AnimalFamily};AnimalKind:{AnimalKind};IsExtinct:{IsExtinct}";

    }
}
