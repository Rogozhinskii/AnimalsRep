using AnimalsLib.Interfaces;

namespace AnimalsLib
{
    /// <summary>
    /// Базовый класс для всех птиц
    /// </summary>
    public class Birds : Animal
    {
        /// <summary>
        /// Для создания птиц
        /// </summary>
        /// <param name="family">отряд животного</param>
        /// <param name="kind">вид животного</param>
        /// <param name="isExtinct">вымирает true/false</param>
        public Birds(string family, string kind, bool isExtinct)
            : base(AnimalSquard.Birds, family, kind,isExtinct) { }

        
    }
}
