using _Scripts.SaveAndManager;
using UnityEngine;

namespace _Scripts.Player
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
