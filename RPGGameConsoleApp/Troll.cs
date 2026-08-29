namespace RPGGameConsoleApp
{
    public class Troll
    {
        private const int _armor = 5;

        private int _health = 150;

        public string Name => "Троль";

        public int Health => _health;

        public bool IsAlive => _health > 0;

        public int ExpReward => 20;

        public int Armor => _armor;

        public void TakeDamage(int amount, bool ignoreArmor = false)
        {
            int real = ignoreArmor ? amount : amount - _armor;

            _health -= Math.Max(real, 0);

            if (_health < 0)
            {
                _health = 0;
            }
        }
    }
}
