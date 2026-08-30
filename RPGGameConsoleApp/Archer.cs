namespace RPGGameConsoleApp
{
    public partial class Archer : Hero
    {
        public Archer(string name)
            : base(name, hp: 90, strength: 10, agility: 15)
        {
        }
        /// <summary>
        /// Имя класса герой
        /// </summary>
        public override string ClassName => "Лучник";
        /// <summary>
        /// Атака лучника, урон
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public override int Attack(IEnemy enemy)
        {
            int damage = Strength / 2 + Agility;

            // 25% шанс нанести критический удар, удваивающий урон
            Random random = new Random();
            if (random.Next(100) < 25)
            {
                damage *= 2;
            }

            enemy.TakeDamage(damage);
            return damage;
        }
    }
}
