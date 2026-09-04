
namespace RPGGameConsoleApp.Monster
{
    internal class GiantSpider : IEnemy
    {
        /// <summary>
        /// Броня по умолчанию Гигантского Паука Шелоб
        /// </summary>
        private const int _armor = 8;
        /// <summary>
        /// Кол-во жизней по умолчанию монстра Гигантского Паука Шелоб
        /// </summary>
        private int _health = 100;
        /// <summary>
        /// Сила атаки по умолчанию Гигантского Паука Шелоб
        /// </summary>
        private int _strength = 7;
        /// <summary>
        /// Имя врага, монстра
        /// </summary>
        public string Name => "Гигантский Паук Шелоб";
        /// <summary>
        /// Кол-во жизней монстра Гигантского Паука Шелоб
        /// </summary>
        public int Health => _health;
        /// <summary>
        /// Гигантский Паук Шелоб живой или нет
        /// </summary>
        public bool IsAlive => _health > 0;
        /// <summary>
        /// Кол-во очков за убийство Гигантского Паука Шелоб
        /// </summary>
        public int ExpReward => 60;
        /// <summary>
        /// Кол-во брони у Гигантского Паука Шелоб
        /// </summary>
        public int Armor => _armor;
        /// <summary>
        /// Сила атаки Гигантского Паука Шелоб
        /// </summary>
        public int Strength => _strength;
        /// <summary>
        /// Урон наносимый Гигантским Пауком Шелоб
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public int DealsDamage(Hero.Hero hero)
        {
            int damage = Strength * 2;
            hero.TakeDamage(damage);
            return damage;
        }
        /// <summary>
        /// Урон получаемый Гигантским Пауком Шелоб
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="ignoreArmor"></param>
        public void TakeDamage(int amount, bool ignoreArmor = false)
        {
            int realDamage = ignoreArmor ? amount : amount - _armor;

            _health -= Math.Max(realDamage, 0);

            if (_health < 0)
            {
                _health = 0;
            }
        }
    }
}
