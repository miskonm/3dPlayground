using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Playground
{
    public class SceneLoader : MonoBehaviour
    {
        private AsyncOperation loadScene;

        private bool allowSceneActivation;

        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadAsync(string sceneName, bool allowSceneActivation = true)
        {
            StartCoroutine(LoadAsyncInternal(sceneName, allowSceneActivation));
        }

        public void AllowSceneActivation()
        {
            loadScene.allowSceneActivation = true;
        }

        private IEnumerator LoadAsyncInternal(string sceneName, bool allowSceneActivation)
        {
            loadScene = SceneManager.LoadSceneAsync(sceneName);
            loadScene.allowSceneActivation = allowSceneActivation;

            while (!loadScene.isDone)
            {
                yield return null;
            }

            loadScene = null;
        }
    }
}
