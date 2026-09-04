using System.Diagnostics;
using System.Text;

namespace RPGGameConsoleApp
{
    public class MiniGame
    {
        public int Play()
        {
            Console.WriteLine("\n=== ЛОВИ ЗВЕЗДЫ · 10 СЕКУНД ===");
            Console.WriteLine("Как только появится иконка, нажми любую клавишу ...");
            Console.WriteLine();

            var random = new Random();
            
            int stars = 0;

            var watch = Stopwatch.StartNew();

            bool visible = false;

            var nextStarTime = TimeSpan.Zero;

            while (watch.Elapsed.TotalSeconds < 10)
            {
                if (!visible && watch.Elapsed >= nextStarTime)
                {
                    Console.OutputEncoding = Encoding.UTF8;

                    // Выводим звезду
                    Console.Write("⭐ ");
                    visible = true;
                }

                if (Console.KeyAvailable)
                {
                    Console.ReadKey(intercept: true);
                    if (visible)
                    {
                        stars++;
                        visible = false;
                        nextStarTime = watch.Elapsed + TimeSpan.FromMilliseconds(random.Next(500, 1500));
                    }
                }
            }

            Console.WriteLine($"Поймано звезд: {stars}");

            return stars;
        }
    }
}
