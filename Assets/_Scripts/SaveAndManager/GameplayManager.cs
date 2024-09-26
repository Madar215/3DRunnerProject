using System;
using TMPro;
using UnityEngine;

namespace _Scripts.SaveAndManager
{
    public class GameplayManager : MonoBehaviour
    {
        private PlayerData _playerData;
        private ControlSchemeE _controlSchemeE;
        private float _score;
        
        [Header("Input")]
        [SerializeField] private GameObject touchInput;
        [SerializeField] private GameObject buttonsInput;

        [SerializeField] private float pointsPerSec = 10f;
        [SerializeField] private TMP_Text scoreText;

        private void Awake()
        {
            _playerData = SaveSystem.LoadPlayerData();
            _controlSchemeE = _playerData.ControlScheme;
        }

        private void Start()
        {
            if (_controlSchemeE == ControlSchemeE.Touch)
            {
                touchInput.SetActive(true);
            }
            else
            {
                buttonsInput.SetActive(true);   
            }
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
    }
}
