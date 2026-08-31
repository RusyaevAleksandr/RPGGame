using RPGGameConsoleApp.Monster;

namespace RPGGameConsoleApp.Hero
{
    public class Healer : Hero
    {
        public Healer(string name) 
            : base(name, hp: 80, strength: 5, agility: 8)
        {
        }
        /// <summary>
        /// Имя класса герой
        /// </summary>
        public override string ClassName => "Целитель";
        /// <summary>
        /// Атака целителя, урон
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public override int Attack(IEnemy enemy)
        {
            int damage = Strength / 4 + Agility;

            // Исцеляет себя с 15% вероятностью после каждой атаки,
            // кол-во очков исцеления жизни равно урону нанесенному противнику 
            Random random = new Random();
            if (random.Next(100) < 15)
            {
                Health += damage;
            }            

            if (Health > 80)
            {
                Health = 80;
            }

            enemy.TakeDamage(damage);
            return damage;
        }
    }
}
