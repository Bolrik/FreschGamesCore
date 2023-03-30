using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace FreschGames.Core.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        UIDocument Document { get; set; }
        ProgressBar Progress { get; set; }
        int LoadIndex { get; set; }

        private void Start()
        {
            this.Progress = this.Document.rootVisualElement.Q<ProgressBar>("LoadingBar");

            this.StartCoroutine(this.LoadScene());
        }

        public void SetData(UIDocument document, int loadIndex)
        {
            this.Document = document;
            this.LoadIndex = loadIndex;
        }

        IEnumerator LoadScene()
        {
            AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(this.LoadIndex);

            Debug.Log($"Now Loading Scene {this.LoadIndex}");

            while (!operation.isDone)
            {
                float progress = (operation.progress / .9f).Clamp(0, 1);
                this.Progress.value = progress;
                yield return null;
            }

            Debug.Log($"Done Loading Scene {this.LoadIndex}");
        }
    }
}
