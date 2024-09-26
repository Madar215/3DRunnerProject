using _Scripts.Pools.Obstacles;
using _Scripts.Pools.Road;
using UnityEngine;

namespace _Scripts.Pools
{
    public class ObjectPoolDestroyer : MonoBehaviour
    {
        private RoadPoolManager _roadPoolManager;
        private EnvironmentPoolManager _environmentPoolManager;
        
        [SerializeField] private RoadPoolSpawner roadPoolSpawner;
        [SerializeField] private EnvironmentPoolSpawner environmentPoolSpawner;

        private void Awake()
        {
            _roadPoolManager = GetComponentInParent<RoadPoolManager>();
            _environmentPoolManager = GetComponentInParent<EnvironmentPoolManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Road"))
            {
                // remove the road part from the active road list
                roadPoolSpawner.RemoveFromActiveRoad(other.gameObject);
                // return the road part to pool
                _roadPoolManager.ReturnObjectToPool(other.gameObject);
                return;
            }

            if (other.CompareTag("Rock"))
            {
                // remove the rock from the active environment list
                environmentPoolSpawner.RemoveFromActiveEnvironment(other.gameObject);
                // return the rock to pool
                _environmentPoolManager.ReleaseRock(other.gameObject);
                return;
            }

            if (other.CompareTag("Tree"))
            {
                // remove the tree from the active environment list
                environmentPoolSpawner.RemoveFromActiveEnvironment(other.gameObject);
                // return the rock to pool
                _environmentPoolManager.ReleaseTree(other.gameObject);
            }
        }
    }
}
