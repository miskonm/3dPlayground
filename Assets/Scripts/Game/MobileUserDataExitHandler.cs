using UnityEngine;
using Zenject;

namespace Playground.Game
{
    public class MobileUserDataExitHandler : MonoBehaviour, IUserDataExitHandler
    {
        private UserDataService userDataService;

        [Inject]
        public void Construct(UserDataService userDataService)
        {
            this.userDataService = userDataService;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
                Save();
        }

        public void Prepare() { }

        private void Save() => 
                userDataService.Save();
    }
}
