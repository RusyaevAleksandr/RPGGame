using RPGGameConsoleApp.Monster;

namespace RPGGameConsoleApp.Hero
{
    public abstract class Hero
    {
        /// <summary>
        /// Имя героя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Кол-во жизней героя
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// Сила героя
        /// </summary>
        public int Strength { get; private set; }
        /// <summary>
        /// Ловкость героя
        /// </summary>
        public int Agility { get; private set; }
        /// <summary>
        /// Уровень героя
        /// </summary>
        public LevelProgress LevelProgress { get; } = new LevelProgress();
        public int SumStars { get; private set; }
        /// <summary>
        /// Герой живой или нет
        /// </summary>
        public bool IsAlive => Health > 0;
        public Hero(string name, int hp, int strength, int agility)
        {
            Name = name;
            Health = hp;
            Strength = strength;
            Agility = agility;
        }
        /// <summary>
        /// Добавление звезд
        /// </summary>
        /// <param name="stars"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddStars(int stars)
        {
            if (stars < 0)
            {
                throw new ArgumentException("Количество звезд не может быть отрицательным");
            }                

            Strength += stars;

            Agility += stars;

            SumStars += stars;
        }
        public int GetFinalInvoice()
        {
            return SumStars + (LevelProgress.Level * 100);
        }
        public void Heal(int countTreatmentPoints)
        {
            if (countTreatmentPoints < 0)
            {
                throw new ArgumentException("Количество очков лечения не может быть отрицательным");
            }

            Health += countTreatmentPoints;

            if (Health > 100)
            {
                Health = 100;
            }
        }
        /// <summary>
        /// Атака героя, наносит урон
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public abstract int Attack(IEnemy enemy);
        /// <summary>
        /// Имя класса герой
        /// </summary>
        public abstract string ClassName { get; }
        /// <summary>
        /// Отобразить характеристики героя
        /// </summary>
        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"Имя героя: {Name}");
            Console.WriteLine($"Класс героя: {ClassName}");
            Console.WriteLine($"Здоровье: {Health}");
            Console.WriteLine($"Сила: {Strength}");
            Console.WriteLine($"Ловкость: {Agility}");
            Console.WriteLine($"Уровень: {LevelProgress.Level}");
            Console.WriteLine();
        }
        /// <summary>
        /// Получает урон герой
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Урон не может быть отрицательным");
            }

            Health -= damage;

            if (Health < 0)
            {
                Health = 0;
            }
        }
    }
}
