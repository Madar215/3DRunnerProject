using System.IO;
using UnityEngine;

namespace SaveAndManager
{
    [System.Serializable]
    public static class SaveSystem
    {
        private static string _pathPlayer = Application.persistentDataPath + "/player.json";
        private static string _pathLeaderboard = Application.persistentDataPath + "/leaderboard.json";
        public static void SavePlayerData(PlayerData playerData)
        {
            string json = JsonUtility.ToJson(playerData);
            File.WriteAllText(_pathPlayer, json);
        }

        public static PlayerData LoadPlayerData()
        {
            if (!File.Exists(_pathPlayer)) return new PlayerData("default", 0, ControlSchemeE.Button);
            
            string json = File.ReadAllText(_pathPlayer);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            return playerData;
        }

        public static void SaveLeaderboardData(LeaderboardData leaderboardData)
        {
            string json = JsonUtility.ToJson(leaderboardData);
            File.WriteAllText(_pathLeaderboard, json);
        }

        public static LeaderboardData LoadLeaderboardData()
        {
            if (!File.Exists(_pathLeaderboard)) return new LeaderboardData();

            string json = File.ReadAllText(_pathLeaderboard);
            LeaderboardData leaderboardData = JsonUtility.FromJson<LeaderboardData>(json);
            return leaderboardData;
        }
    }
}
