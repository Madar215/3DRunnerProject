using UnityEngine;

namespace _Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Forces")]
        [SerializeField] private float movingSpeed = 100f;
        
        [Header("Lane Variables")]
        [SerializeField] private int rightLaneX = 1;
        [SerializeField] private int leftLaneX = -1;

        private float _targetPos;
        
        private int _lanePos;
        private bool _isMovingRight;
        private bool _isMovingLeft;
        
        private void Update()
        {
            
            if (_isMovingRight && _lanePos < rightLaneX)
            {
                _targetPos++;
                _lanePos++;
            }

            if (_isMovingLeft && _lanePos > leftLaneX)
            {
                _targetPos--;
                _lanePos--;
            }
            
            _isMovingRight = false;
            _isMovingLeft = false;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_targetPos, transform.position.y, transform.position.z), movingSpeed * Time.deltaTime);
        }

        public void MovePlayerRight()
        {
            _isMovingRight = true;
        }

        public void MovePlayerLeft()
        {
            _isMovingLeft = true;
        }
    
    }
}
