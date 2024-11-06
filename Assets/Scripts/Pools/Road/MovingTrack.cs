using UnityEngine;
using UnityEngine.Serialization;

namespace Pools.Road
{
    public class MovingTrack : MonoBehaviour
    {
        [SerializeField] private float baseSpeed = 8f;
        
        private float _curSpeed;

        private void Update()
        {
            transform.Translate(Vector3.back * (_curSpeed * Time.deltaTime));
        }

        public void ResetSpeed()
        {
            _curSpeed = baseSpeed;
        }

        public void IncreaseSpeed()
        {
            _curSpeed += 1f;
        }
    }
}
