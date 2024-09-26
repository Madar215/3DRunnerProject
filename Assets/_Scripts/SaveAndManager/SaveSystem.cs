using System.IO;
using UnityEngine;

namespace _Scripts.SaveAndManager
{
    [System.Serializable]
    public static class SaveSystem
    {
        private static string _path = Application.persistentDataPath + "/savefile.json";
        public static void SavePlayerData(PlayerData playerData)
        {
            string json = JsonUtility.ToJson(playerData);
            File.WriteAllText(_path, json);
        }

        public static PlayerData LoadPlayerData()
        {
            if (!File.Exists(_path)) return new PlayerData("default", 0, ControlSchemeE.Button);
            
            string json = File.ReadAllText(_path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            return playerData;
        }
    }
}
