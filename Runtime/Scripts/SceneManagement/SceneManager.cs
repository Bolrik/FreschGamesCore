using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace FreschGames.Core.SceneManagement
{
    // [CreateAssetMenu(fileName = "Scene Manager", menuName = "Data/Scenes/new Scene Manager")]
    public class SceneManager : ScriptableObject
    {
        [field: SerializeField] public int SceneToLoadBuildIndex { get; private set; }

        [field: SerializeField] public VisualTreeAsset LoadingAsset { get; private set; }
        [field: SerializeField] public PanelSettings PanelSettings { get; private set; }

        bool IsLoading { get; set; }
        int LoadCounter { get; set; }

        Scene LoadScene { get; set; }

        public void Load(int index)
        {
            if (this.IsLoading)
            {
                if (this.LoadCounter > 0)
                    return;
            }

            this.IsLoading = true;
            this.SceneToLoadBuildIndex = index;
            this.LoadCounter = UnityEngine.SceneManagement.SceneManager.sceneCount;

            this.LoadScene = UnityEngine.SceneManagement.SceneManager.CreateScene("Loading Scene");

            for (int i = this.LoadCounter - 1; i >= 0; i--)
            {
                AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(
                    UnityEngine.SceneManagement.SceneManager.GetSceneAt(i));
                operation.completed += this.Operation_Completed;
            }
        }

        private void Load()
        {
            // UnityEngine.SceneManagement.SceneManager.LoadScene(this.LoadingSceneBuildIndex);
            UnityEngine.SceneManagement.SceneManager.SetActiveScene(this.LoadScene);

            GameObject gameObject = new GameObject("Loading");
            SceneLoader sceneLoader = gameObject.AddComponent<SceneLoader>();
            UIDocument document = gameObject.AddComponent<UIDocument>();

            document.visualTreeAsset = this.LoadingAsset;
            document.panelSettings = this.PanelSettings;

            sceneLoader.SetData(document, this.SceneToLoadBuildIndex);
        }

        private void Operation_Completed(AsyncOperation obj)
        {
            this.LoadCounter--;

            if (this.LoadCounter <= 0)
            {
                Debug.Log("All Operations Done!");

                this.IsLoading = false;
                this.Load();
            }
        }
    }
}
