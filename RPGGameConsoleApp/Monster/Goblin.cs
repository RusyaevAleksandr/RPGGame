namespace RPGGameConsoleApp.Monster
{
    public class Goblin: IEnemy
    {
        /// <summary>
        /// Броня по умолчанию Гоблина
        /// </summary>
        private const int _armor = 3;
        /// <summary>
        /// Кол-во жизней по умолчанию монстра Гоблина
        /// </summary>
        private int _health = 30;
        /// <summary>
        /// Имя врага, монстра
        /// </summary>
        public string Name => "Гоблин";
        /// <summary>
        /// Кол-во жизней монстра Гоблина
        /// </summary>
        public int Health => _health;
        /// <summary>
        /// Гоблин живой или нет
        /// </summary>
        public bool IsAlive => _health > 0;
        /// <summary>
        /// Кол-во очков за убийство Гоблина
        /// </summary>
        public int ExpReward => 20;
        /// <summary>
        /// Кол-во брони у Гоблина
        /// </summary>
        public int Armor => _armor;
        /// <summary>
        /// Урон получаемый Гоблином
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
