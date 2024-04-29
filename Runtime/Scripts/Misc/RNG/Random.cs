using System;

namespace FreschGames.Core.RNG
{
    public class Random
    {
        public int Seed { get; private set; }


        private int Mul { get; set; }
        private int Mod { get; } = 2147483647; // Highest int Prime
        private int Stp { get; set; }



        // Constructor to set the initial seed
        public Random(int seed)
        {
            this.Seed = seed;
            this.Mul = 10000 + (this.Seed * this.Seed) % 90000;
            this.Stp = 0;
        }

        public Random() : this(Environment.TickCount)
        {

        }

        public int Next()
        {
            this.Seed = ((this.Seed + this.Stp) * this.Mul) % this.Mod;
            this.Stp++;

            return this.Seed;
        }

        public int Next(int maxValue)
        {
            return Next() % maxValue;
        }

        public int Next(int minValue, int maxValue)
        {
            return minValue + Next(maxValue - minValue);
        }

        public double NextDouble()
        {
            return (double)Next() / this.Mod;
        }

        public bool NextBoolean()
        {
            return Next() % 2 == 0;
        }
    }
}
