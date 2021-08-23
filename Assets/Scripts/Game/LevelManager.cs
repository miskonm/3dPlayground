using System.Collections.Generic;
using Playground.Game;

public class LevelManager
{
    private readonly LevelLoader levelLoader;

    private readonly List<Coin> allCoins = new List<Coin>();

    public LevelManager(LevelLoader levelLoader)
    {
        this.levelLoader = levelLoader;
    }

    public void RegisterCoin(Coin coin)
    {
        if (!allCoins.Contains(coin))
            allCoins.Add(coin);
    }

    public void DeregisterCoin(Coin coin)
    {
        if (!allCoins.Remove(coin))
            return;

        AddCoinsToUser(coin);
        CheckEndLevel();
    }

    private void CheckEndLevel()
    {
        if (allCoins.Count == 0)
            EndLevel();
    }

    private void EndLevel()
    {
        UserDataService.Instance.IncrementLevelCompleted();

        levelLoader.LoadGameLevel();
    }

    private void AddCoinsToUser(Coin coin)
    {
        UserDataService.Instance.AddCoins(coin.Cost);
    }
}
