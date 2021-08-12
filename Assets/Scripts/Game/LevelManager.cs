using System.Collections.Generic;
using Playground.Game;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private readonly List<Coin> allCoins = new List<Coin>();

    public void RegisterCoin(Coin coin)
    {
        if(!allCoins.Contains(coin))
            allCoins.Add(coin);
    }

    public void DeregisterCoin(Coin coin)
    {
        if (allCoins.Remove(coin))
            CheckEndLevel();
    }

    private void CheckEndLevel()
    {
        if (allCoins.Count == 0)
            EndLevel();
    }

    private void EndLevel()
    {
        Debug.LogError($"Level completed!");
    }
}
