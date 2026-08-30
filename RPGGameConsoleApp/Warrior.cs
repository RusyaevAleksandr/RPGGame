namespace RPGGameConsoleApp
{
    public class Warrior : Hero
    {
        public Warrior(string name)
            : base(name, hp: 120, strength: 15, agility: 8)
        {
        }
        /// <summary>
        /// Имя класса герой
        /// </summary>
        public override string ClassName => "Воин";
        /// <summary>
        /// Атака война, урон
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public override int Attack(IEnemy enemy)
        {
            int damage = Strength * 2;
            enemy.TakeDamage(damage);
            return damage;
        }
    }
}
