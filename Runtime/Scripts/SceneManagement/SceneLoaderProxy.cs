using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FreschGames.Core.SceneManagement
{
    [CreateAssetMenu(fileName = "Scene Loader Proxy", menuName = "Data/Scenes/new Scene Loader Proxy")]
    public class SceneLoaderProxy : ScriptableObject
    {
        [field: SerializeField] public int SceneBuildIndexToLoad { get; private set; }
        [field: SerializeField] private int LoadingSceneBuildIndex { get; set; }


        public void Load(int index)
        {
            this.SceneBuildIndexToLoad = index;

            SceneManager.LoadScene(this.LoadingSceneBuildIndex);
        }
    }
}
