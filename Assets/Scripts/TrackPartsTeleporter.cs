using UnityEngine;

namespace _Scripts
{
    public class TrackPartsTeleporter : MonoBehaviour
    {
        [SerializeField] private Vector3 teleportLocation = new Vector3(0f, -0.7f, 12.5f); 
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Finish")) return;
            other.transform.position = teleportLocation;
        }
    }
}
