using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreschGames.Core.Misc
{
    public class ProxyCollider : MonoBehaviour
    {
        [field: SerializeField] public Transform Proxy { get; private set; }
    }
}