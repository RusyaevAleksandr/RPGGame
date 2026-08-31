namespace RPGGameConsoleApp
{
    public class LevelProgress
    {
        /// <summary>
        /// Уровень героя
        /// </summary>
        public int Level { get; private set; } = 1;
        /// <summary>
        /// Опыт героя
        /// </summary>
        public int Exp { get; private set; } = 0;
        /// <summary>
        /// Кол-во опыта необходимого для перехода на следующий уровень
        /// </summary>
        public int ExpToNextLevel => Level * 50;
        /// <summary>
        /// Метод добавления опыта герою
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddExp(int amount)
        {
            Exp += amount;

            bool leveledUp = false;

            while (Exp >= ExpToNextLevel)
            {
                Exp -= ExpToNextLevel;
                Level++;
                leveledUp = true;
            }

            return leveledUp;
        }
    }
}
