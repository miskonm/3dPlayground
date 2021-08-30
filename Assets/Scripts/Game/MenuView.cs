using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Playground.Game
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Text coinsLabel;
        [SerializeField] private Text moneyLabel;
        [SerializeField] private Text levelsCompletedLabel;

        private SceneLoader sceneLoader;
        private UserDataService userDataService;

        [Inject]
        public void Construct(SceneLoader sceneLoader, UserDataService userDataService)
        {
            this.userDataService = userDataService;
            this.sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            playButton.onClick.AddListener(PlayButtonClicked);

            UpdateLabels();
        }

        private void PlayButtonClicked()
        {
            sceneLoader.LoadAsync("LoadingScene");
        }

        private void UpdateLabels()
        {
            coinsLabel.text = $"Coins: {userDataService.GetCoins()}";
            moneyLabel.text = $"Money: {userDataService.GetMoney()}";
            levelsCompletedLabel.text = $"Level Completed: {userDataService.GetLevelCompletedCount()}";
        }
    }
}
