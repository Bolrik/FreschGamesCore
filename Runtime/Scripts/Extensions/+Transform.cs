using FreschGames.Core.Misc;

namespace UnityEngine
{
    public static partial class Extension
    {
        private static T GetComponent<T>(this Transform transform)
            where T : Component
        {
            if (transform.GetComponent<T>() is T t1)
            {
                return t1;
            }

            if (transform.GetComponent<ProxyCollider>() is ProxyCollider proxy && proxy.Proxy.GetComponent<T>() is T t2)
            {
                return t2;
            }

            return null;
        }
    }
}
