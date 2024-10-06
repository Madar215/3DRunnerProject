using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Forces")]
        [SerializeField] private float movingSpeed = 100f;
        [SerializeField] private float jumpingForce = 10f;
        
        [Header("Lane Variables")]
        [SerializeField] private int rightLaneX = 1;
        [SerializeField] private int leftLaneX = -1;
        
        [Header("Ground")]
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float groundCheckRadius = 2f;
        [SerializeField] private float groundPosition = 0.5f;

        private Rigidbody _rb;

        private float _targetPos;
        private int _lanePos;
        
        private bool _isMovingRight;
        private bool _isMovingLeft;
        private bool _isJumping;
        private bool _isGrounded = true;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _isGrounded = GroundCheck();
            
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

            if (_isJumping && _isGrounded)
            {
                _rb.AddForce(Vector3.up * jumpingForce);
            }
            
            _isMovingRight = false;
            _isMovingLeft = false;
            _isJumping = false;
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

        public void Jump()
        {
            _isJumping = true;
        }

        private bool GroundCheck()
        {
            Vector3 pos = transform.position + (Vector3.down * groundPosition);
            return Physics.CheckSphere(pos, groundCheckRadius, groundLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 pos = transform.position + (Vector3.down * groundPosition);
            Gizmos.DrawSphere(pos, groundCheckRadius);
        }
    }
}
