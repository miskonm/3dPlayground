using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Playground.Game
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private SceneLoader sceneLoader;
        

        private void Awake()
        {
            playButton.onClick.AddListener(PlayButtonClicked);
        }

        private void PlayButtonClicked()
        {
            sceneLoader.LoadAsync("LoadingScene");
        }
    }
}
