using TMPro;
using UnityEngine;

namespace _Scripts.SaveAndManager
{
    public class Leaderboard : MonoBehaviour
    {
        private static LeaderboardData _leaderboardData;

        private Transform _scoreContainer;
        
        [SerializeField] private Transform scoreTemplate;
        [SerializeField] private float scoreTemplateOffset = 25f;

        private void Awake()
        {
            _leaderboardData = SaveSystem.LoadLeaderboardData();
            ArrangeLeaderboard();
            _scoreContainer = GetComponent<Transform>();
            scoreTemplate.gameObject.SetActive(false);
        }

        public void ShowLeaderboard()
        {
            for (int i = 0; i < 10; i++)
            {
                Transform score = Instantiate(scoreTemplate, _scoreContainer);
                RectTransform scoreRect = score.GetComponent<RectTransform>();
                scoreRect.anchoredPosition = new Vector2(0, -scoreTemplateOffset * i);
                score.gameObject.SetActive(true);

                int rank = i + 1;
                string rankString = rank switch
                {
                    1 => "1ST",
                    2 => "2ND",
                    3 => "3RD",
                    _ => rank + "TH"
                };

                score.Find("Pos").GetComponent<TMP_Text>().text = rankString;
                score.Find("Name").GetComponent<TMP_Text>().text = _leaderboardData.Datas[i].Name;
                score.Find("Score").GetComponent<TMP_Text>().text = _leaderboardData.Datas[i].Score.ToString();
            }
        }

        private void ArrangeLeaderboard()
        {
            int n = _leaderboardData.Datas.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (_leaderboardData.Datas[j].Score < _leaderboardData.Datas[min].Score)
                    {
                        min = j;
                    }
                }
                
                // if smaller score found, swap them.
                if (min != i)
                {
                    // swap
                    (_leaderboardData.Datas[i].Score, _leaderboardData.Datas[min].Score) = (_leaderboardData.Datas[min].Score, _leaderboardData.Datas[i].Score);
                }
            }
        }

        public static bool SubmitScore(PlayerData playerData)
        {
            int loopSize = _leaderboardData.Datas.Length;
            for (int i = 0; i < loopSize; i++)
            {
                if (playerData.Score <= _leaderboardData.Datas[i].Score) continue;
                
                _leaderboardData.Datas[i].Score = playerData.Score;
                _leaderboardData.Datas[i].Name = playerData.Name;
                SaveSystem.SaveLeaderboardData(_leaderboardData);
                return true;
            }

            return false;
        }
    }
}
