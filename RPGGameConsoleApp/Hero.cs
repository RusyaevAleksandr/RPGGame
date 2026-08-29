namespace RPGGameConsoleApp
{
    public abstract class Hero
    {
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Strength { get; private set; }
        public int Agility { get; private set; }

        //public LevelProgress LevelProgress { get; private set; } = new LevelProgress();

        public bool IsAlive => Hp > 0;
        public Hero(string name, int hp, int strength, int agility)
        {
            Name = name;
            Hp = hp;
            Strength = strength;
            Agility = agility;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Урон не может быть отрицательным");
            }                

            Hp -= damage;
            if (Hp < 0)
            {
                Hp = 0;
            }                
        }

        public void AddStars(int stars)
        {
            if (stars < 0)
            {
                throw new ArgumentException("Количество звезд не может быть отрицательным");
            }                

            Strength += stars;
            Agility += stars;
        }

        public void Heal(int countTreatmentPoints)
        {
            if (countTreatmentPoints < 0)
            {
                throw new ArgumentException("Количество очков лечения не может быть отрицательным");
            }

            Hp += countTreatmentPoints;

            if (Hp > 100)
            {
                Hp = 100;
            }
        }

        //public abstract int Attack(IEnemy enemy);

        //public abstract string ClassName { get; }

        //public void Display()
        //{
        //    Console.WriteLine($"Имя героя: {Name}");
        //    Console.WriteLine($"Класс героя: {ClassName}");
        //    Console.WriteLine($"Здоровье: {Hp}");
        //    Console.WriteLine($"Сила: {Strength}");
        //    Console.WriteLine($"Ловкость: {Agility}");
        //    Console.WriteLine($"Уровень: {LevelProgress.Level}");
        //    Console.WriteLine();
        //}
    }
}
