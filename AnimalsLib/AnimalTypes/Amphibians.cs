using AnimalsLib.Interfaces;

namespace AnimalsLib
{
    /// <summary>
    /// Базовый класс для всех представителей амфибий
    /// </summary>
    public class Amphibians : Animal
    {

        /// <summary>
        /// Для создания амфибий
        /// </summary>
        /// <param name="family">отряд животного</param>
        /// <param name="kind">вид животного</param>  
        /// <param name="isExtinct">вымирает true/false</param>
        public Amphibians(string family, string kind,bool isExtinct)
            : base(AnimalSquard.Amphibians, family, kind, isExtinct) { }

       
    }
}
