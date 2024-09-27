using System;
using TMPro;
using UnityEngine;

namespace _Scripts.SaveAndManager
{
    public class GameplayManager : MonoBehaviour
    {
        private PlayerData _playerData;
        private static int _controlScheme;
        private float _score;
        
        [Header("Input")]
        [SerializeField] private GameObject touchInput;
        [SerializeField] private GameObject buttonsInput;
        private static GameObject[] _inputArray;
        
        [Header("Score")]
        [SerializeField] private float pointsPerSec = 10f;
        [SerializeField] private TMP_Text scoreText;

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
        }

        private void Update()
        {
            _score += pointsPerSec * Time.deltaTime;
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
    }
}
