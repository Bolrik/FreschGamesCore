using UnityEngine;

namespace FreschGames.Core.ResourceSystem
{
    [DefaultExecutionOrder(-50)]
    public class AssetSystem : MonoBehaviour
    {
        [field: SerializeField] public AssetGroup[] Groups { get; private set; }

        private void OnEnable()
        {
            foreach (var group in this.Groups)
            {
                group.Load();
            }
        }
    }
}
