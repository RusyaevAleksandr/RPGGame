namespace RPGGameConsoleApp
{
    public interface IEnemy
    {
        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Здоровье
        /// </summary>
        int Health { get; }
        /// <summary>
        /// Броня
        /// </summary>
        int Armor { get; }
        /// <summary>
        /// Живой или нет
        /// </summary>
        bool IsAlive { get; }
        /// <summary>
        /// Опыт за победу
        /// </summary>
        int ExpReward { get; }
        /// <summary>
        /// Полученный урон
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="ignoreArmor"></param>
        void TakeDamage(int amount, bool ignoreArmor = false);
    }
}
