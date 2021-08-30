namespace Playground.Game
{
    public class LevelLoader
    {
        private readonly SceneLoader sceneLoader;
        private readonly UserDataService userDataService;

        public LevelLoader(SceneLoader sceneLoader, UserDataService userDataService)
        {
            this.sceneLoader = sceneLoader;
            this.userDataService = userDataService;
        }

        public void LoadGameLevel(bool allowSceneActivation = true)
        {
            // var numberOfLevelCompleted = userDataService.GetLevelCompletedCount();
            // var sceneName = numberOfLevelCompleted < 4 ? SceneNames.Level1 : SceneNames.Level2;
            var sceneName = SceneNames.Level1;

            sceneLoader.LoadAsync(sceneName, allowSceneActivation);
        }

        public void AllowSceneActivation()
        {
            sceneLoader.AllowSceneActivation();
        }
    }
}
