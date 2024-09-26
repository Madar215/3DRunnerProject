
namespace _Scripts.SaveAndManager
{
    [System.Serializable]
    public class LeaderboardData
    {
        public string[] name;
        public int[] score;

        public LeaderboardData()
        {
            name = new string[10];
            score = new int[10];
        }
    }
}
