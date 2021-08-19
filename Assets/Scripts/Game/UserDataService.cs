using System;
using System.IO;
using NaughtyAttributes;
using UnityEngine;

namespace Playground.Game
{
    public class UserDataService : MonoBehaviour
    {
        private const string Tag = nameof(UserDataService);
        private const string PrefsKey = "UserData";
        
        [SerializeField] private UserData userData;

        private IFileIO fileIO;

        private static UserDataService instance;

        public static UserDataService Instance
        {
            get
            {
                if (instance != null)
                    return instance;

                var go = new GameObject(Tag);
                var service = go.AddComponent<UserDataService>();

                DontDestroyOnLoad(go);

                instance = service;

                return instance;
            }
        }

        private void Awake()
        {
            fileIO = new JsonFileIO();

            Load();
            
            if (instance != null)
                return;
        }

        private void OnDisable()
        {
            Save();
            
            Debug.LogError($"SAVE");
        }

        [Button()]
        public void Save()
        {
            var path = GetFullPath();

            fileIO.Write(path, userData);
        }

        [Button()]
        public void Load()
        {
            userData = fileIO.Read<UserData>(GetFullPath());

            if (userData == default)
            {
                SetDefaultUserData();
            }
        }

        public void AddCoins(int coinCost) => userData.coins += coinCost;

        public int GetCoins() => userData.coins;

        public void AddMoney(int money)
        {
            userData.money += money;
        }

        public int GetMoney()
        {
            return userData.money;
        }

        public void IncrementLevelCompleted()
        {
            userData.numbersOfLevelCompleted++;
        }

        public int GetLevelCompletedCount() => userData.numbersOfLevelCompleted;

        private string GetFullPath()
        {
            return Path.Combine(Application.persistentDataPath, "UserData.txt");
        }

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
