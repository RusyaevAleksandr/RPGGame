namespace RPGGameConsoleApp
{
    public interface IEnemy
    {
        string Name { get; }
        int Health { get; }
        int Armor { get; }
        bool IsAlive { get; }
        int ExpReward { get; } // опыт за победу
        void TakeDamage(int amount, bool ignoreArmor = false);
    }
}
