using AnimalsLib.Interfaces;

namespace AnimalsLib
{
    /// <summary>
    /// Базовый класс для всех птиц
    /// </summary>
    public class Birds : Animal,ITypedAnimal
    {
        /// <summary>
        /// Размах крыльев
        /// </summary>
        public double Wingspan { get; set; }

        public AnimalType AnimalType { get; }

        /// <summary>
        /// Для создания птиц
        /// </summary>
        /// <param name="squad">отряд животного</param>
        /// <param name="kind">вид животного</param>
        /// <param name="wingspen">размах крыльев</param>
        public Birds(string squad, string kind,double wingspen) 
            : base(squad, kind)
        {
            AnimalType = AnimalType.Birds;
            Wingspan = wingspen;
        }
    }
}
