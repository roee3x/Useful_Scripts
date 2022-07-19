
/// in here i will show example of how to use the system.
//IMPORTANT, Make sure you use this only in ONE SCRIPT. otherwise it will create multiple gameData files and override each other on load.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//You can use any name you want, I even used it inside the game manager.
public class SavingComponent : MonoBehaviour
{
    //in order to save & load you must have a reference to the data
    public GameData gameData;

    private void LoadDataUp()
    {
        //you can do this on awake or start as well
        //You can now load the game
        gameData = SaveSystem.Load(); 

        //once you loaded you can fill the gaps
        playerData.Strength = gameData.power;
        playerData.Health = gameData.health;
        playerData.Defence = gameData.defence;
        playerData.playerName = gameData.savedName;
        playerData.Money = gameData.totalCoins;
    }

    private void SaveDataUp()
    {
        //you can call this once, or you can call this specifically when needed
        //first you need to cash the references, then save
        gameData.totalCoins = playerData.Money; //float
        gameData.health = playerData.Health;
        gameData.defence = playerData.Defence; 
        gameData.power = playerData.Strength; //int
        gameData.isAlive = playerData.Alive; //bool
        gameData.savedName = playerData.playerName; //string

        SaveSystem.Save(gameData); 
        //now the data is saved.
    }
}