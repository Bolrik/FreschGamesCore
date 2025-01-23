using FreschGames.Core;

namespace UnityEngine
{
    public static partial class Extension
    {
        public static T GetRelayComponent<T>(this Transform transform)
            where T : class
        {
            if (transform.GetComponent<T>() is T value) return value;

            if (transform.GetComponent<Proxy>() is Proxy relay && relay.GetComponent<T>() is T proxyValue) return proxyValue;

            return null;
        }

        public static void DestroyAllChildren(this Transform parent)
        {
            int childCount = parent.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                Transform child = parent.GetChild(i);
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
