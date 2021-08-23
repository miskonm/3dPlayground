using UnityEngine;
using Zenject;

namespace Playground.Game
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int cost = 1;

        private LevelManager levelManager;

        public int Cost => cost;

        [Inject]
        public void Construct(LevelManager levelManager)
        {
            this.levelManager = levelManager;
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
