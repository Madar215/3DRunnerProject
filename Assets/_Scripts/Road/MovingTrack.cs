using UnityEngine;

namespace _Scripts.Road
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
