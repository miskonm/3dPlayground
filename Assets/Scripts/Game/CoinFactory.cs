using UnityEngine;
using Zenject;

namespace Playground.Game
{
    public class CoinFactory
    {
        private readonly DiContainer diContainer;
        private readonly Coin coinPrefab;

        public CoinFactory(DiContainer diContainer, Coin coinPrefab)
        {
            this.diContainer = diContainer;
            this.coinPrefab = coinPrefab;
        }

        public Coin Create(Transform parent)
        {
            return diContainer.InstantiatePrefabForComponent<Coin>(coinPrefab, parent);
        }
    }
}
