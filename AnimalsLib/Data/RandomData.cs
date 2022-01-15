namespace AnimalsLib.Data
{
    public class RandomData
    {
        private readonly static string[] _amphibiansSquard;
        private readonly static string[] _birdsSquard;
        private readonly static string[] _mammalsSquard;
        private readonly static string[] _families;
        private readonly static string[] _kinds;
        private readonly static bool[] _extinct;
        private static Random rnd;

        static RandomData()
        {
            rnd=new Random();
            _amphibiansSquard = new string[]
            {
                "frog",
                "salamander",
                "turtle"
            };
            _birdsSquard = new string[]
            {
                "owl",
                "falcon",
                "eagle"
            };
            _mammalsSquard = new string[]
            {
                "dog",
                "lion",
                "squirrel"
            };
            _families = new string[]
            {
                "бессяжковые",
                "хордовые",
                "Лососёвые",
                "кошачьи",
                "жабы",
                "тушкашчиковые",
                "беличьи"
            };
            _kinds = new string[]
            {
                "обыкновешшый",
                "африканский",
                "снежный",
                "глубоководный",
                "мерзкий",
                "длинноухий",
            };
            _extinct = new bool[]
            {
                false,true
            };
        }

        /// <summary>
        ///  Возвращает случайного представителя отряда амфибий
        /// </summary>
        /// <returns></returns>
        public static string GetRandomAmfibianSquard() =>
            rnd.NextItem(_amphibiansSquard);

        /// <summary>
        /// Возвращает случайного представителя отряда птичьих
        /// </summary>
        /// <returns></returns>
        public static string GetRandomBirdsSquard() =>
           rnd.NextItem(_birdsSquard);

        /// <summary>
        /// Возвращает случайного представителя отряда млекопитающих
        /// </summary>
        /// <returns></returns>
        public static string GetRandomMammalsSquard() =>
           rnd.NextItem(_mammalsSquard);

        /// <summary>
        /// Возвращает случайное семейство животного
        /// </summary>
        /// <returns></returns>
        public static string GetRandomFamily() =>
           rnd.NextItem(_families);

        /// <summary>
        /// Возвращает случайный вид животного
        /// </summary>
        /// <returns></returns>
        public static string GetRandomKinds() =>
           rnd.NextItem(_kinds);

        public static bool GetRandomExtinct() =>
          rnd.NextItem(_extinct);


    }
}
