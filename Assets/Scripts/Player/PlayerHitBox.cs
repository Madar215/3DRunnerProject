using SaveAndManager;
using UnityEngine;

namespace Player
{
    public class PlayerHitBox : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] private GameplayManager gameplayManager;
        [SerializeField] private AudioManager audioManager;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Obstacle")) return;
            
            audioManager.PlayCrashSfx();
            gameplayManager.TriggerLose();
        }
    }
}
