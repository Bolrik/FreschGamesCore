using UnityEngine;

namespace FreschGames.Core
{
    public class Proxy : MonoBehaviour
    {
        [field: SerializeField] public Transform Transform { get; private set; }
    }
}