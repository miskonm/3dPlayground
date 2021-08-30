using System.Collections.Generic;
using Playground.Game;

public class LevelManager
{
    private readonly LevelLoader levelLoader;
    private readonly UserDataService userDataService;

    private readonly List<Coin> allCoins = new List<Coin>();

    public LevelManager(LevelLoader levelLoader, UserDataService userDataService)
    {
        this.levelLoader = levelLoader;
        this.userDataService = userDataService;
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
        userDataService.IncrementLevelCompleted();

        levelLoader.LoadGameLevel();
    }

    private void AddCoinsToUser(Coin coin)
    {
        userDataService.AddCoins(coin.Cost);
    }
}
