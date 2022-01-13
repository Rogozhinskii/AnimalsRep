using AnimalsLib.Interfaces;

namespace AnimalsLib
{
    /// <summary>
    /// Базовый класс для всех птиц
    /// </summary>
    public class Birds : Animal
    {
        /// <summary>
        /// Размах крыльев
        /// </summary>
        public double Wingspan { get; set; }

        

        /// <summary>
        /// Для создания птиц
        /// </summary>
        /// <param name="squad">отряд животного</param>
        /// <param name="kind">вид животного</param>
        /// <param name="wingspen">размах крыльев</param>
        public Birds(string squad, string kind,double wingspen) 
            : base(AnimalType.Birds,squad, kind)
        {            
            Wingspan = wingspen;
        }

        public override string ToString()
        {
            return base.ToString() + $"Wingspan:{Wingspan};";
        }
    }
}
