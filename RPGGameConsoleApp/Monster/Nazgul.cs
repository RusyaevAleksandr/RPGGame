namespace RPGGameConsoleApp.Monster
{
    public class Nazgul : IEnemy
    {
        /// <summary>
        /// Броня по умолчанию Назгула
        /// </summary>
        private const int _armor = 10;
        /// <summary>
        /// Кол-во жизней по умолчанию монстра Назгула
        /// </summary>
        private int _health = 80;
        /// <summary>
        /// Сила атаки по умолчанию Назгула
        /// </summary>
        private int _strength = 12;
        /// <summary>
        /// Имя врага, монстра
        /// </summary>
        public string Name => "Назгул";
        /// <summary>
        /// Кол-во жизней монстра Назгула
        /// </summary>
        public int Health => _health;
        /// <summary>
        /// Назгул живой или нет
        /// </summary>
        public bool IsAlive => _health > 0;
        /// <summary>
        /// Кол-во очков за убийство Назгула
        /// </summary>
        public int ExpReward => 70;
        /// <summary>
        /// Кол-во брони у Назгула
        /// </summary>
        public int Armor => _armor;
        /// <summary>
        /// Сила атаки Назгула
        /// </summary>
        public int Strength => _strength;
        /// <summary>
        /// Урон наносимый Назгулом
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
        /// Урон получаемый Назгулом
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="ignoreArmor"></param>
        public void TakeDamage(int amount, bool ignoreArmor = false)
        {
            int realDamage = ignoreArmor ? amount - _armor/2 : amount - _armor;

            _health -= Math.Max(realDamage, 0);

            if (_health < 0)
            {
                _health = 0;
            }
        }
    }
}
