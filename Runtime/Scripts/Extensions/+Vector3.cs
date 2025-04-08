namespace UnityEngine
{
    public static partial class Extension
    {
        public static float Angel(this Vector3 a, Vector3 b)
        {
            return Vector3.Angle(a, b);
        }
        
        public static Vector3 ClampMagnitude(this Vector3 a, float distance)
        {
            return Vector3.ClampMagnitude(a, distance);
        }
        
        public static float Distance(this Vector3 a, Vector3 b)
        {
            return Vector3.Distance(a, b);
        }

        public static Vector3 Lerp(this Vector3 a, Vector3 b, float t)
        {
            return Vector3.Lerp(a, b, t);
        }

        public static Vector3 MoveTowards(this Vector3 origin, Vector3 target, float distance)
        {
            return Vector3.MoveTowards(origin, target, distance);
        }
    }
}
