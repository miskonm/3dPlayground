using UnityEngine;

namespace Playground.Game
{
    public class Coin : MonoBehaviour
    {
        private LevelManager levelManager;

        private void Awake()
        {
            levelManager = FindObjectOfType<LevelManager>();
        }

        private void OnEnable()
        {
            levelManager.RegisterCoin(this);
        }

        private void OnDisable()
        {
            levelManager.DeregisterCoin(this);
        }

        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}
