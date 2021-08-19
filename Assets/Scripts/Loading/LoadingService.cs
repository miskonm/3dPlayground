using System.Collections;
using Playground.Game;
using UnityEngine;

namespace Playground
{
    public class LoadingService : MonoBehaviour
    {
        [SerializeField] private LevelLoader levelLoader;
        [SerializeField] private float minLoadingTime = 2f;

        private void Start()
        {
            levelLoader.LoadGameLevel(false);
            StartCoroutine(StartSceneAfterDelay());
        }

        private IEnumerator StartSceneAfterDelay()
        {
            yield return new WaitForSeconds(minLoadingTime);

            levelLoader.AllowSceneActivation();
        }
    }
}
