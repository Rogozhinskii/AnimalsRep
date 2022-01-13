namespace AnimalsLib.ConcreteAnimals
{
    internal class UnknownAnimal : Animal
    {

        public UnknownAnimal(AnimalSquard squad = AnimalSquard.Unknown, 
                       string family="не понятный", 
                       string kind="не определен",
                       bool isExtinct=false) : base(squad, family, kind, isExtinct)
        {
        }
    }
}
