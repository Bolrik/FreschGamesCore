using FreschGames.Core.StateSystem;
using UnityEngine;

namespace FreschGames.Core.BootSystem
{
    [DefaultExecutionOrder(-50)]
    public class BootManager : MonoBehaviour
    {
        [field: SerializeField] public BootStep[] Steps { get; private set; }

        private void OnEnable()
        {
            if (State<BootManager>.Instance is not null)
                return;

            State<BootManager>.Assign(this);

            foreach (var step in this.Steps)
            {
                step.Load();
            }

            DontDestroyOnLoad(this.gameObject);
        }
    }
}