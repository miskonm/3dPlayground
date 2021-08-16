using System;
using NaughtyAttributes;
using UnityEngine;

namespace Playground.Game
{
    public class UserDataService : MonoBehaviour
    {
        private const string PrefsKey = "UserData";
        public UserData userData;

        [Button()]
        public void Add()
        {
            Debug.Log($"Add BEFORE <{userData.GetLifes()}>");
            userData.coins++;
            userData.money++;
            userData.IncrementLifes();
            Debug.Log($"Add AFTER <{userData.GetLifes()}>");
        }
        
        [Button()]
        public void Save()
        {
            var json = JsonUtility.ToJson(userData);
            
            Debug.Log($"{json}");
            
            PlayerPrefs.SetString(PrefsKey, json);
        }

        [Button()]
        public void Load()
        {
            var json = PlayerPrefs.GetString(PrefsKey);

            try
            {
                JsonUtility.FromJsonOverwrite(json, userData);
            }
            catch
            {
                userData = new UserData
                {
                    coins = 10,
                    money = 6
                };
            }
           
            
            Debug.Log($"Add AFTER <{userData.GetLifes()}>");
        }
    }
}
