
namespace SaveAndManager
{
    public class LeaderboardData
    {
        public Data[] Datas = new Data[10];

        public LeaderboardData()
        {
            for (int i = 0; i < Datas.Length; i++)
            {
                Datas[i] = new Data{ Name = "", Score = 0};
            }
        }
        
        public struct Data
        {
            public string Name;
            public int Score;
        }
    }
}
