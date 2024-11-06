using System;
using Pools.Road;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveAndManager
{
    public class GameplayManager : MonoBehaviour
    {
        private PlayerData _playerData;
        private static int _controlScheme;
        private float _score;
        private float _timeSinceLastInc;
        
        [Header("Input")]
        [SerializeField] private GameObject touchInput;
        [SerializeField] private GameObject buttonsInput;
        private static GameObject[] _inputArray;
        
        [Header("Score")]
        [SerializeField] private float pointsPerSec = 10f;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private float scoreMultiplier = 1f;
        [SerializeField] private float scoreIncreaseInterval = 10f;
        
        [Header("UI")]
        [SerializeField] private TMP_Text submitText;
        [SerializeField] private TMP_Text gameOverScoreText;
        [SerializeField] private GameObject gameOverUi;

        [Header("Managers")]
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private MovingTrack movingTrack;

        private void Awake()
        {
            // load player data from main menu
            _playerData = SaveSystem.LoadPlayerData();
            // process his ControlScheme enum to int
            _controlScheme = (int)_playerData.ControlScheme;
            // initialize the input array with both buttons and touch input
            _inputArray = new[] { touchInput, buttonsInput };
        }

        private void Start()
        {
            // active the player input preference based on the control scheme
            _inputArray[_controlScheme].SetActive(true);
            
            // Set track speed to base speed
            movingTrack.ResetSpeed();
        }

        private void Update()
        {
            _timeSinceLastInc += Time.deltaTime;
            
            if (_timeSinceLastInc < scoreIncreaseInterval) return;
            
            // Add to the score multiplier
            scoreMultiplier += 0.2f;
            
            // Increase track speed
            movingTrack.IncreaseSpeed();
            
            // Reset the timer
            _timeSinceLastInc = 0f;
        }

        private void LateUpdate()
        {
            _score += pointsPerSec * Time.deltaTime * scoreMultiplier;
            scoreText.text = RoundFloat(_score).ToString();
        }

        private int RoundFloat(float score)
        {
            return (int)MathF.Round(score);
        }

        public static void PauseGame()
        {
            Time.timeScale = 0f;
            
            _inputArray[_controlScheme].SetActive(false);
        }

        public static void ResumeGame()
        {
            Time.timeScale = 1f;
            
            _inputArray[_controlScheme].SetActive(true);
        }

        public void SubmitScore()
        {
            bool submit = Leaderboard.SubmitScore(_playerData);
            submitText.gameObject.SetActive(true);

            submitText.text = submit ? "Score was submitted" : "Your score is not high enough";
        }

        public void RetryGame()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }

        public void ReturnToMainMenu()
        {
            // Main menu is in build index = 0.
            SceneManager.LoadSceneAsync(0);
            Time.timeScale = 1f;
        }

        public void TriggerLose()
        {
            PauseGame();

            _playerData.Score = (int)_score;

            gameOverUi.SetActive(true);

            gameOverScoreText.text = scoreText.text;
        }
    }
}
