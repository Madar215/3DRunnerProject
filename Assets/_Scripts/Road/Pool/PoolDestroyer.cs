using UnityEngine;

namespace _Scripts.Road.Pool
{
    public class PoolDestroyer : MonoBehaviour
    {
        private PoolManager _poolManager;
        
        [SerializeField] private PoolSpawner poolSpawner;

        private void Awake()
        {
            _poolManager = GetComponentInParent<PoolManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Finish")) return;
            
            // remove the road part from the active road list
            poolSpawner.RemoveFromActiveRoad(other.gameObject);
            
            // return the road part to pool
            _poolManager.ReturnObjectToPool(other.gameObject);
        }
    }
}
