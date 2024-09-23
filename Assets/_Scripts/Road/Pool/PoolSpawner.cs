using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Road.Pool
{
    public class PoolSpawner : MonoBehaviour
    {
        [SerializeField] private int numActiveRoad = 10;
        [SerializeField] private float roadLength = 4f;
        [SerializeField] private float roadPosOffset = 0.95f;

        private List<GameObject> _activeRoads = new();

        private PoolManager _poolManager;

        private GameObject _newRoad;
        private GameObject _lastRoad;

        private void Awake()
        {
            _poolManager = GetComponentInParent<PoolManager>();
        }

        private void Start()
        {
            for (int i = 0; i < numActiveRoad; i++)
            {
                _newRoad = _poolManager.GetObjectFromPool();
                _activeRoads.Add(_newRoad);
                
                // the first road will be positioned in (o, o, o)
                if (i == 0)
                {
                    _newRoad.transform.position = new Vector3(0f, 0f, 0f);
                    _lastRoad = _newRoad;
                    continue;
                }
                
                // position new road at the position of the last road + the road length
                var targetPos = _lastRoad.transform.position.z;
                _newRoad.transform.position = new Vector3(0f, 0f, targetPos + roadLength);
                _lastRoad = _newRoad;
            }
        }

        private void Update()
        {
            if (_activeRoads.Count == numActiveRoad) return;
            
            // get road part from pool and add it to active roads list
            _newRoad = _poolManager.GetObjectFromPool();
            _activeRoads.Add(_newRoad);
            
            //position it at the position of the last road + the road length
            var targetPos = _lastRoad.transform.position.z;
            _newRoad.transform.position = new Vector3(0f, 0f, targetPos + (roadLength * roadPosOffset));
            _lastRoad = _newRoad;
        }

        public void RemoveFromActiveRoad(GameObject obj)
        {
            _activeRoads.Remove(obj);
        }
    }
}
