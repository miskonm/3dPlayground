using System.Collections;
using Playground.Game;
using UnityEngine;
using Zenject;

namespace Playground
{
    public class GameLauncher : MonoBehaviour
    {
        private UserDataService userDataService;
        private SceneLoader sceneLoader;
        private IUserDataExitHandler userDataExitHandler;

        [Inject]
        public void Construct(UserDataService userDataService, SceneLoader sceneLoader,
            IUserDataExitHandler userDataExitHandler)
        {
            this.userDataExitHandler = userDataExitHandler;
            this.userDataService = userDataService;
            this.sceneLoader = sceneLoader;
        }

        private void Start()
        {
            StartAllSystem();
        }

        private void StartAllSystem()
        {
            StartUserDataService();
            StartDelayBeforeLoadScene();
        }

        private void StartUserDataService()
        {
            userDataExitHandler.Prepare();
            userDataService.Load();
        }

        private void StartDelayBeforeLoadScene()
        {
            StartCoroutine(LoadMenuAfterDelay());
        }

        private IEnumerator LoadMenuAfterDelay()
        {
            yield return new WaitForSeconds(0.5f);

            sceneLoader.Load(SceneNames.Menu);
        }
    }
}
