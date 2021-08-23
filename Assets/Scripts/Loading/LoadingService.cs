using System.Collections;
using Playground.Game;
using UnityEngine;
using Zenject;

namespace Playground
{
    public class LoadingService : MonoBehaviour
    {
        [SerializeField] private float minLoadingTime = 2f;

        private LevelLoader levelLoader;

        [Inject]
        public void Construct(LevelLoader levelLoader)
        {
            this.levelLoader = levelLoader;
        }

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
