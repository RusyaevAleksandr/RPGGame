namespace RPGGameConsoleApp
{
    public class Goblin
    {
        private const int _armor = 3;

        private int _health = 30;

        public string Name => "Гоблин";

        public int Health => _health;

        public bool IsAlive => _health > 0;

        public int ExpReward => 20;

        public int Armor => _armor;

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
