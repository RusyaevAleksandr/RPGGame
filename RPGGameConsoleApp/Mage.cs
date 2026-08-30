namespace RPGGameConsoleApp
{
    public class Mage : Hero
    {
        public Mage(string name)
            : base(name, hp: 80, strength: 8, agility: 10)
        {
        }
        /// <summary>
        /// Имя класса герой
        /// </summary>
        public override string ClassName => "Маг";
        /// <summary>
        /// Атака мага, урон
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public override int Attack(IEnemy enemy)
        {
            int damage = Strength * 3;
            enemy.TakeDamage(damage, ignoreArmor: true);
            return damage;
        }
    }
}
