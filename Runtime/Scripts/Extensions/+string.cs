namespace System
{
    public static partial class Extension
    {
        public static int GetStableHash(this string value)
        {
            const int BaseHash = 2017;

            unchecked
            {
                int hash = BaseHash;

                foreach (char c in value)
                {
                    hash = hash * 31 + c;
                }

                return hash;
            }
        }
    }
}
