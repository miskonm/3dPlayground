using UnityEngine;
using Zenject;

namespace Playground.Game
{
    public class CoinCreator : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;

        private CoinFactory coinFactory;

        [Inject]
        public void Construct(CoinFactory coinFactory)
        {
            this.coinFactory = coinFactory;
        }

        private void Start()
        {
            SpawnCoins();
        }

        private void SpawnCoins()
        {
            if (spawnPoints == null)
                return;

            foreach (Transform spawnPoint in spawnPoints)
            {
                if(spawnPoint == null)
                    continue;

                coinFactory.Create(spawnPoint);
            }
        }
    }
}
