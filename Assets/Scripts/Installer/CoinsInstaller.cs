using Playground.Game;
using Zenject;

namespace Playground
{
    public class CoinsInstaller : MonoInstaller
    {
        public Coin coinPrefab;

        public override void InstallBindings()
        {
            Container.Bind<CoinFactory>().AsSingle().WithArguments(coinPrefab);
        }
    }
}
