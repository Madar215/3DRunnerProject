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
            _scoreContainer = GetComponent<Transform>();
            scoreTemplate.gameObject.SetActive(false);
        }

        private void Start()
        {
            ShowLeaderboard();
        }

        private void ShowLeaderboard()
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
    }
}
