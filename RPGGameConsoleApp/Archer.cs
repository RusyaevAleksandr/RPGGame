namespace RPGGameConsoleApp
{
    public class Archer : Hero
    {
        public class Mage : Hero
        {
            public Mage(string name)
                : base(name, hp: 80, strength: 8, agility: 10)
            {
            }

            public override string ClassName => "Маг";

            public override int Attack(IEnemy enemy)
            {
                int damage = Strength * 3;
                enemy.TakeDamage(damage, ignoreArmor: true);
                return damage;
            }
        }
        public Archer(string name)
            : base(name, hp: 90, strength: 10, agility: 15)
        {
        }

        public override string ClassName => "Лучник";


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
