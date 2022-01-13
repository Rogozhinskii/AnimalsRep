using AnimalsLib.Interfaces;

namespace AnimalsLib
{
    /// <summary>
    /// Базовый класс для всех представителей амфибий
    /// </summary>
    public class Amphibians : Animal
    {
        
        /// <summary>
        /// Максимальная глубина погружения
        /// </summary>
        public int MaxImmersionDepth { get; set; }

        /// <summary>
        /// Для создания амфибий
        /// </summary>
        /// <param name="squad">отряд животного</param>
        /// <param name="kind">вид животного</param>
        /// <param name="deph">максимальная глубина погружения</param>
        public Amphibians(string squad, string kind,int deph) 
            : base(AnimalType.Amphibians,squad, kind)
        {            
            MaxImmersionDepth = deph;
        }

        public override string ToString()
        {
            return base.ToString() + $"Max Immersion Depth:{MaxImmersionDepth};";
        }
    }
}
