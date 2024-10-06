
namespace SaveAndManager
{
    [System.Serializable]
    public class LeaderboardData
    {
        public Data[] Datas = new Data[10];
        
        public struct Data
        {
            public string Name;
            public int Score;
        }
    }
}
