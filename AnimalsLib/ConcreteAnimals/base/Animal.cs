namespace AnimalsLib
{
    public abstract class Animal : IAnimal
    {
        public Guid Id { get; set; }
        public string AnimalFamily { get; set; }
        public string AnimalKind { get; set; }
        public AnimalSquard AnimalSquard { get; set; }

        public bool IsExtinct { get; set; }

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
            $"AnimalSquard:{AnimalSquard}; AnimalFamily:{AnimalFamily}; AnimalKind:{AnimalKind}; IsExtinct:{IsExtinct}";

    }
}
