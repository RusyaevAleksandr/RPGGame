using RPGGameConsoleApp.Hero;

namespace RPGGameConsoleApp.Monster
{
    public interface IEnemy
    {
        /// <summary>
        /// Имя врага
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Здоровье врага
        /// </summary>
        int Health { get; }
        /// <summary>
        /// Броня врага
        /// </summary>
        int Armor { get; }
        /// <summary>
        /// Сила монстра
        /// </summary>
        int Strength { get; }
        /// <summary>
        /// Живой враг или нет
        /// </summary>
        bool IsAlive { get; }
        /// <summary>
        /// Кол-во опыта за победу над данным врагом
        /// </summary>
        int ExpReward { get; }
        /// <summary>
        /// Полученный урон
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="ignoreArmor"></param>
        void TakeDamage(int amount, bool ignoreArmor = false);
        /// <summary>
        /// Атака монстра, наносит урон
        /// </summary>
        /// <param name="hero"></param>
        int DealsDamage(Hero.Hero hero);
    }
}
