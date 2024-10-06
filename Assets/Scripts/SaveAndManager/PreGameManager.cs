using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SaveAndManager
{
    public class PreGameManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField] private TMP_Text userFeedback;
        [SerializeField] private Button touchButton;
        [SerializeField] private Button buttonsButton;
        [SerializeField] private Button playButton;
        
        // validation that the player wrote a valid name and chose controls
        private bool _isValidateText;
        private bool _controlChoose;
        // controls the user can choose
        private bool _isTouch;
        private bool _isButtons;
        
        private void Start()
        {
            nameInput.onEndEdit.AddListener(delegate { ValidateString(nameInput.text); });
        }

        private void Update()
        {
            if (!_isValidateText || !_controlChoose) return;
            
            SetPlayButton();
        }

        private void ValidateString(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
            {
                nameInput.image.color = Color.red;
                userFeedback.gameObject.SetActive(true);
                userFeedback.text = "Wrong Input! Enter Valid Name:";
            }
            else
            {
                _isValidateText = true;
                nameInput.image.color = Color.green;
                userFeedback.gameObject.SetActive(false);
            }
        }

        public void TouchButtonClicked()
        {
            if (buttonsButton.image.color == Color.green)
                buttonsButton.image.color = Color.white;
            
            _isTouch = true;
            _isButtons = false;
            _controlChoose = true;
            touchButton.image.color = Color.green;
        }

        public void UiButtonClicked()
        {
            if(touchButton.image.color == Color.green)
                touchButton.image.color = Color.white;
            
            _isButtons = true;
            _isTouch = false;
            _controlChoose = true;
            buttonsButton.image.color = Color.green;
        }

        private void SetPlayButton()
        {
            if (playButton.gameObject.activeInHierarchy) return;
            
            playButton.gameObject.SetActive(true);
        }

        public void PlayGame()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            
            if (_isTouch)
            {
                SaveSystem.SavePlayerData(new PlayerData(nameInput.text, 0, ControlSchemeE.Touch));
            }
            else if (_isButtons)
            {
                SaveSystem.SavePlayerData(new PlayerData(nameInput.text, 0, ControlSchemeE.Button));
            }
        }
    }
}
