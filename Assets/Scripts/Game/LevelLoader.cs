using UnityEngine;

namespace Playground.Game
{
    public class LevelLoader
    {
        private readonly SceneLoader sceneLoader;

        public LevelLoader(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public void LoadGameLevel(bool allowSceneActivation = true)
        {
            var numberOfLevelCompleted = UserDataService.Instance.GetLevelCompletedCount();
            // var sceneName = numberOfLevelCompleted < 4 ? "Level1" : "Level2";
            var sceneName = "Level1";

            sceneLoader.LoadAsync(sceneName, allowSceneActivation);
        }

        public void AllowSceneActivation()
        {
            sceneLoader.AllowSceneActivation();
        }
    }
}
