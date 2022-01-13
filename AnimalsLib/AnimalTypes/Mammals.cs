using AnimalsLib.Interfaces;

namespace AnimalsLib
{
    /// <summary>
    /// Базовый класс для всех представителей млекопитающих
    /// </summary>
    public class Mammals : Animal,ITypedAnimal
    {
        /// <summary>
        /// Находится ли живоетное под угрозой вымирания
        /// </summary>
        public bool Extinction { get; set; }

        public AnimalType AnimalType { get; }

        /// <summary>
        /// Для создания млекопитающих 
        /// </summary>
        /// <param name="squad">отряд животного</param>
        /// <param name="kind">вид животного</param>
        /// <param name="isExtinct">Вымирает ли вид</param>
        public Mammals(string squad, string kind,bool isExtinct) 
            : base(squad, kind)
        {
            AnimalType = AnimalType.Mammals;
            Extinction = isExtinct;
        }
    }
}
