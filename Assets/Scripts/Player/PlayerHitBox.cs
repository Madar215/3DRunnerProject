using SaveAndManager;
using UnityEngine;

namespace Player
{
    public class PlayerHitBox : MonoBehaviour
    {
        [SerializeField] private GameplayManager gameplayManager;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Obstacle")) return;
            
            gameplayManager.TriggerLose();
        }
    }
}
