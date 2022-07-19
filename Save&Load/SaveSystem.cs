using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SaveAndLoad
{
    public class SaveSystem
    {
        public static void Save(GameData data)
        {
            Debug.LogWarning("I SAVE");
            // i use GetPath instead -- string path = Application.persistentDataPath + "/SavedData.qnd";
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(GetPath(), FileMode.Create);
            formatter.Serialize(fileStream, data);
            fileStream.Close();
        }

        public static GameData Load()
        {
            Debug.LogWarning("I LOAD");
            if(!File.Exists(GetPath()))
            {
                GameData emptyData = new GameData();
                Save(emptyData);
                return emptyData;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(GetPath(), FileMode.Open);
            GameData data = formatter.Deserialize(fileStream) as GameData;
            fileStream.Close();

            return data;
        }

        private static string GetPath()
        {
            return Application.persistentDataPath + "/SavedData.qnd";
        }
    }
}

