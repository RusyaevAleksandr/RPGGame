using System.Text;
using static RPGGameConsoleApp.Archer;

namespace RPGGameConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Добро пожаловать в игру!");
            Console.Write("Введите имя героя: ");
            var name = Console.ReadLine();

            Console.WriteLine("Выберите класс героя:");
            Console.WriteLine("1. Воин");
            Console.WriteLine("2. Маг");
            Console.WriteLine("3. Лучник");
            Console.WriteLine("4. Целитель");
            var choice = Console.ReadLine();

            Hero hero = null;
            switch (choice)
            {
                case "1":
                    hero = new Warrior(name);
                    break;
                case "2":
                    hero = new Mage(name);
                    break;
                case "3":
                    hero = new Archer(name);
                    break;
                case "4":
                    hero = new Healer(name);
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }
            hero.Display();

            IEnemy[] enemies = [new Goblin(), new Troll()];

            var battle = new Battle();

            battle.OnEnemyDefeated += enemy =>
            {
                //var leveledUp = hero.LevelProgress.AddExp(enemy.ExpReward);
                Console.WriteLine($"Опыт +{enemy.ExpReward}");
                //if (leveledUp)
                //{
                //    Console.WriteLine($"{hero.Name} достиг уровня {hero.LevelProgress.Level}!");
                //    hero.Display();
                //}
            };

            //var game = new Game();

            foreach (var enemy in enemies)
            {
                battle.Fight(hero, enemy);

                //var stars = game.Play();
                //hero.AddStars(stars);
                //Console.WriteLine($"Бонус +{stars} к характеристикам {hero.Name}");
                hero.Display();
            }
        }
    }
}
