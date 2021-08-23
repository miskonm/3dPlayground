using TMPro;
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

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
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
            coinsLabel.text = $"Coins: {UserDataService.Instance.GetCoins()}";
            moneyLabel.text = $"Money: {UserDataService.Instance.GetMoney()}";
            levelsCompletedLabel.text = $"Level Completed: {UserDataService.Instance.GetLevelCompletedCount()}";
        }
    }
}
