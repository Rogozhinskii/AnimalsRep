using AnimalsLib.Interfaces;

namespace AnimalsLib
{
    /// <summary>
    /// Базовый класс для всех представителей млекопитающих
    /// </summary>
    public class Mammals : Animal
    {
        /// <summary>
        /// Находится ли живоетное под угрозой вымирания
        /// </summary>
        public bool Extinction { get; set; }

        /// <summary>
        /// Для создания млекопитающих 
        /// </summary>
        /// <param name="squad">отряд животного</param>
        /// <param name="kind">вид животного</param>
        /// <param name="isExtinct">Вымирает ли вид</param>
        public Mammals(string squad, string kind,bool isExtinct) 
            : base(AnimalType.Mammals,squad, kind)
        {            
            Extinction = isExtinct;
        }

        public override string ToString()
        {
            return base.ToString() + $"Extinction:{Extinction};";
        }
    }
}
