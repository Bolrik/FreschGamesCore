using UnityEngine;

namespace FreschGames.Core.TemplateSystem
{
    [DefaultExecutionOrder(-50)]
    public class TemplateSystem : MonoBehaviour
    {
        [field: SerializeField] public TemplateGroup[] Groups { get; private set; }

        private void OnEnable()
        {
            foreach (var group in this.Groups)
            {
                group.Load();
            }
        }
    }
}
