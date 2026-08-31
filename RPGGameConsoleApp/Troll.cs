namespace RPGGameConsoleApp
{
    public class Troll: IEnemy
    {
        /// <summary>
        /// Броня по умолчанию Тролля
        /// </summary>
        private const int _armor = 5;
        /// <summary>
        /// Кол-во жизней по умолчанию монстра Тролля
        /// </summary>
        private int _health = 100;
        /// <summary>
        /// Имя врага, монстра
        /// </summary>
        public string Name => "Тролль";
        /// <summary>
        /// Кол-во жизней монстра Тролля
        /// </summary>
        public int Health => _health;
        /// <summary>
        /// Тролль живой или нет
        /// </summary>
        public bool IsAlive => _health > 0;
        /// <summary>
        /// Кол-во очков за убийство Тролля
        /// </summary>
        public int ExpReward => 50;
        /// <summary>
        /// Кол-во брони у Тролля
        /// </summary>
        public int Armor => _armor;
        /// <summary>
        /// Урон получаемый Троллем
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
