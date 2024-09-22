using UnityEngine;

namespace _Scripts
{
    public class TouchInput : MonoBehaviour
    {
        private Vector2 _startTouchPos;
        private Vector2 _currentTouchPos;

        private bool _isSwiping;

        [SerializeField] private float swipeThreshold = 50f;

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
                    break;
                case TouchPhase.Canceled:
                    _isSwiping = false;
                    break;
                case TouchPhase.Ended:
                    if (_isSwiping)
                    {
                        float swipeDeltaX = _currentTouchPos.x - _startTouchPos.x;
                        float swipeDeltaY = _currentTouchPos.y - _startTouchPos.y;
                        
                        if (Mathf.Abs(swipeDeltaX) > swipeDeltaY)
                        {
                            if (Mathf.Abs(swipeDeltaX) > swipeThreshold)
                            {
                                switch (swipeDeltaX)
                                {
                                    case > 0:
                                        _playerMovement.MovePlayerRight();
                                        break;
                                    case < 0:
                                        _playerMovement.MovePlayerLeft();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            if (swipeDeltaY > swipeThreshold)
                                _playerMovement.Jump();
                        }
                        
                        _isSwiping = false;
                    }
                    break;
            }
            
        }
    }
}
