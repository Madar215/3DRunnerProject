using _Scripts.SaveAndManager;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerHitBox : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Obstacle")) return;
            
            GameplayManager.PauseGame();
        }
    }
}
