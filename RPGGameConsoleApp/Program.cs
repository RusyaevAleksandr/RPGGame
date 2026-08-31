using RPGGameConsoleApp.Hero;
using RPGGameConsoleApp.Monster;
using System.Text;

namespace RPGGameConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Добро пожаловать в игру!");
            Console.WriteLine();
            Console.Write("Введите имя героя: ");
            var name = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Выберите класс героя:");
            Console.WriteLine("1. Воин");
            Console.WriteLine("2. Маг");
            Console.WriteLine("3. Лучник");
            Console.WriteLine("4. Целитель");
            Console.WriteLine();

            bool correctChoice = true;

            Hero.Hero hero = null;

            while (correctChoice)
            {
                Console.Write("Введите цифру: ");
                var choice = Console.ReadLine();
                Console.WriteLine();               

                switch (choice)
                {
                    case "1":
                        hero = new Warrior(name);
                        correctChoice = false;
                        break;
                    case "2":
                        hero = new Mage(name);
                        correctChoice = false;
                        break;
                    case "3":
                        hero = new Archer(name);
                        correctChoice = false;
                        break;
                    case "4":
                        hero = new Healer(name);
                        correctChoice = false;
                        break;
                    default:
                        Console.WriteLine("Ввели некорректные данные. Попробуйте еще раз!");
                        break;
                }
            }            

            hero.Display();

            IEnemy[] enemies = [new Goblin(), new Troll()];

            var battle = new Battle();

            battle.OnEnemyDefeated += enemy =>
            {
                var leveledUp = hero.LevelProgress.AddExp(enemy.ExpReward);

                Console.WriteLine($"Опыт +{enemy.ExpReward}");

                if (leveledUp)
                {
                    Console.WriteLine($"{hero.Name} достиг уровня {hero.LevelProgress.Level}!");

                    hero.Display();
                }
            };
            
            var game = new Game();

            foreach (var enemy in enemies)
            {
                battle.Fight(hero, enemy);

                var stars = game.Play();

                hero.AddStars(stars);

                Console.WriteLine($"Бонус +{stars} к характеристикам {hero.Name}");

                hero.Display();
            }
        }
    }
}
