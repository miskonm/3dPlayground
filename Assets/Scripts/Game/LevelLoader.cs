using UnityEngine;
using UnityEngine.SceneManagement;

namespace Playground.Game
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadNextLevel()
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
