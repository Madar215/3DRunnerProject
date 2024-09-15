using UnityEngine;

namespace _Scripts
{
    public class TouchInput : MonoBehaviour
    {
        private Vector2 _startTouchPos;
        private Vector2 _currentTouchPos;

        private bool _isSwiping;

        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if(Input.touchCount == 0)
                return;
            
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startTouchPos = touch.position;
                    _isSwiping = true;
                    break;
                case TouchPhase.Moved:
                    _currentTouchPos = touch.position;

                    if (_isSwiping)
                    {
                        switch (_currentTouchPos.x - _startTouchPos.x)
                        {
                            case > 1:
                                _playerMovement.MovePlayerRight();
                                break;
                            case < -1:
                                _playerMovement.MovePlayerLeft();
                                break;
                        }
                        
                        if (_currentTouchPos.y - _startTouchPos.y > 1)
                            _playerMovement.Jump();
                        
                        _startTouchPos = _currentTouchPos;
                        _isSwiping = false;
                    }
                    break;
                case TouchPhase.Canceled:
                case TouchPhase.Ended:
                    _isSwiping = false;
                    break;
            }
            
        }
    }
}
