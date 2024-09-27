using _Scripts.Pools.Road;
using _Scripts.SaveAndManager;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerHitBox : MonoBehaviour
    {
        [SerializeField] private MovingTrack movingTrack;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Obstacle")) return;
            
            GameplayManager.PauseGame();
        }
    }
}
