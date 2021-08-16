using System;
using UnityEngine;

namespace Playground.Game
{
    [Serializable]
    public class UserData
    {
        public int coins;
        public int money;
        private int lifes;

        public void IncrementLifes() => lifes++;
        public int GetLifes() => lifes;
    }
}
