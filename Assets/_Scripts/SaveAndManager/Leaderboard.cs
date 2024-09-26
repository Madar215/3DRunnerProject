using UnityEngine;

namespace _Scripts.SaveAndManager
{
    public class Leaderboard : MonoBehaviour
    {
        private static Leaderboard _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this);
        }
    }
}
