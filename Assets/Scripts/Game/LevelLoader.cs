using UnityEngine;

namespace Playground.Game
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;

        public void LoadGameLevel(bool allowSceneActivation = true)
        {
            var numberOfLevelCompleted = UserDataService.Instance.GetLevelCompletedCount();
            var sceneName = numberOfLevelCompleted < 4 ? "Level1" : "Level2";

            sceneLoader.LoadAsync(sceneName, allowSceneActivation);
        }

        public void AllowSceneActivation()
        {
            sceneLoader.AllowSceneActivation();
        }
    }
}
