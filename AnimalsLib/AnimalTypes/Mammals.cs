using AnimalsLib.Interfaces;

namespace AnimalsLib
{
    /// <summary>
    /// Базовый класс для всех представителей млекопитающих
    /// </summary>
    public class Mammals : Animal
    {
        /// <summary>
        /// Для создания млекопитающих 
        /// </summary>
        /// <param name="squad">отряд животного</param>
        /// <param name="kind">вымирает true/false</param>        
        public Mammals(string family, string kind, bool isExtinct) 
            : base(AnimalSquard.Mammals, family, kind, isExtinct)
        {   
        }
               
    }
}
