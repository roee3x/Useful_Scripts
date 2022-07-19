using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SaveAndLoad
{
    [Serializable]
    public class GameData
    {
        public float totalCoins;

        public bool isAlive;
        public float health;
        public float power;
        public float defence;

        public int language;
        public int qualitySettings;

        public string savedName;
        public string faceName;
        public string bodyName;

        public GameData()
        {
            totalCoins = 0;

            isAlive = false;

            health = 30;
            power = 7;
            defence = 0;

            language = 0;
            qualitySettings = 1;

            savedName = "";
            faceName = "";
            bodyName = "";

        }
    }
}


