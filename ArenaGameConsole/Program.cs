using ArenaGameEngine;

namespace ArenaGameConsole
{
    class ConsoleGameEventListener : GameEventListener
    {
        public override void GameRound(Hero attacker, Hero defender, int attack)
        {
            string message = $"{attacker.Name} attacked {defender.Name} for {attack} points";
            if (defender.IsAlive)
            {
                message = message + $" but {defender.Name} survived.";
            }
            else
            {
                message = message + $" and {defender.Name} died.";
            }
            Console.WriteLine(message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight("Sir John");
            Rogue rogue = new Rogue("Slim Shady");
            Controller controller = new Controller("Sir Leo");//New hero 1
            Speedster speedster = new Speedster("El Tigre ");// New hero 2

            Arena arena = new Arena(knight, rogue, controller, speedster);
            arena.EventListener = new ConsoleGameEventListener();

            Console.WriteLine("Battle begins between Knight, Rogue, Controller, Speedster");
            Hero winner = arena.Battle();
            Console.WriteLine($"Battle ended.  Winner is: {winner.Name}");
            Console.ReadLine();
        }
    }
}
