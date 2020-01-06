
namespace ConsoleOpdracht
{
    internal class World
    {
        /// <summary>
        /// Increases the values of a world.
        /// </summary>
        public void NextWorld()
        {   
            Health = Health * 1.337;
            WorldCount++;
            CurrentHealth = Health;
            CoinValue = CoinValue * 1.42;
        }

        /// <summary>
        /// Getters and setters.
        /// </summary>
        public double CoinValue { get; private set; } = 100d;

        public double Health { get; private set; } = 100d;

        public int WorldCount { get; private set; } = 1;

        public double CurrentHealth { get; set; } = 100d;
    }
}
