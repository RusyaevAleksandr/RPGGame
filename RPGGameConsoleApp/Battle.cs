namespace RPGGameConsoleApp
{
    class Battle
    {
        public event Action<IEnemy> OnEnemyDefeated;

        public void Fight(Hero hero, IEnemy enemy)
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
