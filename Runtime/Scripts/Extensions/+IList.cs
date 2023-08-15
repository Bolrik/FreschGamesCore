namespace System.Collections.Generic
{
    public static partial class Extension
    {
        private static Random Random { get; set; } = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            list.Shuffle(Random);
        }

        public static void Shuffle<T>(this IList<T> list, Random random)
        {
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
