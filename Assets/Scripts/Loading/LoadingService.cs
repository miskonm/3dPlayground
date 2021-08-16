using System;
using System.Collections;
using UnityEngine;

namespace Playground
{
    public class LoadingService : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private float minLoadingTime = 2f;

        private void Start()
        {
            sceneLoader.LoadAsync("Level1", false);
            StartCoroutine(StartSceneAfterDelay());
        }

        private IEnumerator StartSceneAfterDelay()
        {
            yield return new WaitForSeconds(minLoadingTime);

            sceneLoader.AllowSceneActivation();
        }
    }
}
