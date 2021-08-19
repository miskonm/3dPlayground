using UnityEngine;

namespace Playground.Game
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int cost = 1;

        private LevelManager levelManager;

        public int Cost => cost;

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
