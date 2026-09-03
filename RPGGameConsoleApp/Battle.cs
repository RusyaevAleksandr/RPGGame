using RPGGameConsoleApp.Monster;
using RPGGameConsoleApp.Hero;

namespace RPGGameConsoleApp
{
    class Battle
    {
        /// <summary>
        /// Событие, оповещение враг повержен.
        /// </summary>
        public event Action<IEnemy> OnEnemyDefeated;
        /// <summary>
        /// Метод сражение, бой
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="enemy"></param>
        public void Fight(Hero.Hero hero, IEnemy enemy)
        {
            Console.WriteLine($"\n=== {hero.Name} против {enemy.Name} ===");

            while (enemy.IsAlive && hero.IsAlive)
            {
                Console.WriteLine();
                Console.WriteLine("Для атаки нажмите любую клавишу...");

                Console.ReadKey();

                int damageHero = hero.Attack(enemy);

                Console.WriteLine($"{hero.Name} бьет {enemy.Name}: -{damageHero} (HP у {enemy.Name} осталось {enemy.Health})");

                if (enemy.IsAlive)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{enemy.Name} наносит ответный удар!");

                    int damageMonster = enemy.DealsDamage(hero);

                    Console.WriteLine($"{enemy.Name} бьет {hero.Name}: -{damageMonster} (HP у {hero.Name} осталось {hero.Health})");
                }
            }

            if (!hero.IsAlive)
            {
                Console.WriteLine();
                Console.WriteLine("Ваш герой повержен!");
            }
            if (!enemy.IsAlive)
            {
                Console.WriteLine();
                Console.WriteLine($"{enemy.Name} повержен!");

                OnEnemyDefeated?.Invoke(enemy);
            }
        }
    }
}
