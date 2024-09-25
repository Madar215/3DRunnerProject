using UnityEngine;

namespace _Scripts
{
    public class GameplayManager : MonoBehaviour
    {
        private PlayerData _playerData;
        private ControlSchemeE _controlSchemeE;
        private int _score;
        
        [Header("Input")]
        [SerializeField] private GameObject touchInput;
        [SerializeField] private GameObject buttonsInput;

        private void Awake()
        {
            _playerData = SaveSystem.LoadPlayerData();
            _controlSchemeE = _playerData.ControlScheme;
            _score = _playerData.Score;
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
    }
}
