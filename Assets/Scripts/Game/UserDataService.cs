using System.IO;
using UnityEngine;

namespace Playground.Game
{
    public class UserDataService 
    {
        private const string Tag = nameof(UserDataService);
        private const string UserDataFileName = "UserData.txt";

        private readonly IFileIO fileIO;
        
        private UserData userData;

        public UserDataService(IFileIO fileIO)
        {
            this.fileIO = fileIO;
        }

        public void Save() => 
                fileIO.Write(GetFullPath(), userData);

        public void Load()
        {
            userData = fileIO.Read<UserData>(GetFullPath());

            if (userData == null)
                SetDefaultUserData();
        }

        public void AddCoins(int coinCost) => 
                userData.coins += coinCost;

        public int GetCoins() => 
                userData.coins;

        public void AddMoney(int money) => 
                userData.money += money;

        public int GetMoney() => 
                userData.money;

        public void IncrementLevelCompleted() => 
                userData.numbersOfLevelCompleted++;

        public int GetLevelCompletedCount() => 
                userData.numbersOfLevelCompleted;
        

        private string GetFullPath() => 
                Path.Combine(Application.persistentDataPath, UserDataFileName);

        private void SetDefaultUserData()
        {
            userData = new UserData
            {
                coins = 0,
                money = 5
            };
        }
    }
}
