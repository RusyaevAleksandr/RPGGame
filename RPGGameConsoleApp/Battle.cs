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

            while (enemy.IsAlive)
            {
                Console.WriteLine("Для атаки нажмите любую клавишу...");

                Console.ReadKey();

                int damage = hero.Attack(enemy);

                Console.WriteLine($"{hero.Name} бьет {enemy.Name}: -{damage}  (осталось {enemy.Health})");
            }

            Console.WriteLine($"{enemy.Name} повержен!");

            OnEnemyDefeated?.Invoke(enemy);
        }
    }
}
