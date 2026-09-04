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
            ShowRules();
            Console.WriteLine();

            bool isEndGame = false;

            while (!isEndGame)
            {
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

                IEnemy[] enemies = [new Goblin(), new Troll(), new GiantSpider(), new Nazgul()];

                var battle = new Battle();

                battle.OnEnemyDefeated += enemy =>
                {
                    if (!enemies.Last().IsAlive)
                    {
                        isEndGame = true;
                    }

                    var leveledUp = hero.LevelProgress.AddExp(enemy.ExpReward);

                    Console.WriteLine();
                    Console.WriteLine($"Опыт +{enemy.ExpReward}");

                    if (leveledUp)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{hero.Name} достиг уровня {hero.LevelProgress.Level}!");

                        hero.Display();
                    }
                };

                battle.OnHeroDefeated += hero =>
                {
                    correctChoice = true;

                    Console.WriteLine("Вы проиграли!");
                    Console.WriteLine();
                    Console.WriteLine("Хотите попробовать еще раз?");
                    Console.WriteLine("1. Да");
                    Console.WriteLine("2. Нет");
                    Console.WriteLine();

                    while (correctChoice)
                    {
                        Console.Write("Введите цифру: ");
                        var choice = Console.ReadLine();
                        Console.WriteLine();

                        switch (choice)
                        {
                            case "1":
                                isEndGame = false;
                                correctChoice = false;
                                break;
                            case "2":
                                isEndGame = true;
                                correctChoice = false;
                                break;
                            default:
                                Console.WriteLine("Ввели некорректные данные. Попробуйте еще раз!");
                                break;
                        }
                    }
                };

                var game = new MiniGame();

                foreach (var enemy in enemies)
                {
                    battle.Fight(hero, enemy);

                    if (hero.IsAlive)
                    {
                        var stars = game.Play();

                        hero.AddStars(stars);

                        Console.WriteLine();
                        Console.WriteLine($"Бонус +{stars} к характеристикам {hero.Name}");

                        hero.Display();
                    }
                    else
                    {
                        break;
                    }
                }

                if (isEndGame == true && hero.IsAlive)
                {
                    var finalInvoice = hero.GetFinalInvoice();

                    Console.WriteLine($"Итоговый счет: {finalInvoice}");
                }
            }
        }

        public static void ShowRules()
        {
            Console.WriteLine("=== ПРАВИЛА ИГРЫ ===");
            Console.WriteLine("1. Цель: победить всех монстров, попасть в топ списка победителей по очкам.");
            Console.WriteLine("2. Выбрать класс героя, каждый имеет свои уникальные характеристики и способности.");
            Console.WriteLine("*  Класс Воин - имеет большой запас жизней, сильный удар, но слабую ловкость");
            Console.WriteLine("*  Класс Маг - имеет небольшой запас жизней, средний удар, среднюю ловкость");
            Console.WriteLine("*  Класс Лучник - имеет средний запас жизней, небольшой удар, высокую ловкость.");
            Console.WriteLine("** Супер способность Лучника: критический удар - 25% шанс нанести критический удар, удваивающий урон");
            Console.WriteLine("*  Класс Целитель - имеет небольшой запас жизней, небольшой удар, среднюю ловкость.");
            Console.WriteLine("** Супер способность исцеление - Исцеляет некоторое кол-во очков жизней с 15% вероятностью после каждой атаки.");
            Console.WriteLine("3. Перед вами появляются монстры по очереди, вы должны сразиться с каждым из них");
            Console.WriteLine("4. После каждого выигранного сражения начинается мини-игра, поймай звезду.");
            Console.WriteLine("*  В течении 10 сек. появляются иконки, каждая пойманная иконка дает +1 к характеристикам героя (сила и ловкость).");
            Console.WriteLine("5. Итоговый счет. Формула подсчета: Уровень героя умножить на 100 + сумма пойманных звезд за всю игру.");
            Console.WriteLine("====================");
        }
    }
}
