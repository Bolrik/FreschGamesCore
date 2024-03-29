﻿using FreschGames.Core.Misc;

namespace UnityEngine
{
    public static partial class Extension
    {
        public static T GetProxyComponent<T>(this Transform transform)
            where T : class
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
