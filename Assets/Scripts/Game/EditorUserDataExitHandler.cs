using UnityEditor;

namespace Playground.Game
{
    public class EditorUserDataExitHandler : IUserDataExitHandler
    {
        private readonly UserDataService userDataService;

        public EditorUserDataExitHandler(UserDataService userDataService)
        {
            this.userDataService = userDataService;
        }

        public void Prepare() => 
                EditorApplication.playModeStateChanged += EditorApplication_OnPlayModeStateChanged;

        private void EditorApplication_OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingPlayMode)
                Save();
        }

        private void Save() => 
                userDataService.Save();
    }
}
