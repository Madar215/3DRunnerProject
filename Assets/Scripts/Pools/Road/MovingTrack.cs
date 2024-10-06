using UnityEngine;

namespace Pools.Road
{
    public class MovingTrack : MonoBehaviour
    {
        [SerializeField] private float trackSpeed = 2f;
    
        void Update()
        {
            transform.Translate(Vector3.back * (trackSpeed * Time.deltaTime));
        }
    }
}
