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

                    /*if (_isSwiping)
                    {
                        float swipeDelta = _currentTouchPos.x - _startTouchPos.x;
                        if (Mathf.Abs(swipeDelta) > swipeThreshold)
                        {
                            switch (swipeDelta)
                            {
                                case > 0:
                                    Debug.Log(swipeDelta);
                                    _playerMovement.MovePlayerRight();
                                    break;
                                case < 0:
                                    Debug.Log(swipeDelta);
                                    _playerMovement.MovePlayerLeft();
                                    break;
                            }
                        }
                        
                        if (_currentTouchPos.y - _startTouchPos.y > swipeThreshold)
                            _playerMovement.Jump();
                        
                        _startTouchPos = _currentTouchPos;
                        _isSwiping = false;
                    }*/
                    break;
                case TouchPhase.Canceled:
                    _isSwiping = false;
                    break;
                case TouchPhase.Ended:
                    if (_isSwiping)
                    {
                        float swipeDelta = _currentTouchPos.x - _startTouchPos.x;
                        if (Mathf.Abs(swipeDelta) > swipeThreshold)
                        {
                            switch (swipeDelta)
                            {
                                case > 0:
                                    Debug.Log(swipeDelta);
                                    _playerMovement.MovePlayerRight();
                                    break;
                                case < 0:
                                    Debug.Log(swipeDelta);
                                    _playerMovement.MovePlayerLeft();
                                    break;
                            }
                        }
                        
                        if (_currentTouchPos.y - _startTouchPos.y > swipeThreshold)
                            _playerMovement.Jump();
                        
                        _startTouchPos = _currentTouchPos;
                        _isSwiping = false;
                    }
                    /*_isSwiping = false;*/
                    break;
            }
            
        }
    }
}
