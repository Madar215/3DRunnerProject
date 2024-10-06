using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pools.Obstacles
{
    public class EnvironmentPoolSpawner : MonoBehaviour
    {
        [Header("Pool Info")] 
        [SerializeField] private int numActiveEnvironmentObject = 15;
        [SerializeField] private int initialTree = 5;
        [SerializeField] private int initialRock = 5;
        [SerializeField] private Transform parentTransform;

        [Header("Randomizer Info")] 
        [SerializeField] private float positiveMinX = 2f;
        [SerializeField] private float positiveMaxX = 10f;
        [SerializeField] private float negativeMinX = 2f;
        [SerializeField] private float negativeMaxX = 10f;
        [SerializeField] private float positiveMinZ = 5f;
        [SerializeField] private float positiveMaxZ = 25f;
        
        private EnvironmentPoolManager _environmentPoolManager;

        private GameObject _tree;
        private GameObject _rock;

        private List<GameObject> _environmentActive = new();
        
        private void Awake()
        {
            _environmentPoolManager = GetComponentInParent<EnvironmentPoolManager>();
        }

        private void Start()
        {
            // create number of trees in random positions
            for (int i = 0; i < initialTree; i++)
            {
                // get random float for x-axis (positive or negative)
                var randomX = Random.value < 0.5f ? Random.Range(positiveMinX, positiveMaxX) : Random.Range(negativeMinX, negativeMaxX);
                
                // get random float for z-axis (only positive)
                var randomZ = Random.Range(positiveMinZ, positiveMaxZ);
                
                SpawnNewTree(randomX, randomZ);
            }
            
            // create number of rocks in random positions
            for (int i = 0; i < initialRock; i++)
            {
                // get random float for x-axis (positive or negative)
                var randomX = Random.value < 0.5f ? Random.Range(positiveMinX, positiveMaxX) : Random.Range(negativeMinX, negativeMaxX);
                
                // get random float for z-axis (only positive)
                var randomZ = Random.Range(positiveMinZ, positiveMaxZ);
                
                SpawnNewRock(randomX, randomZ);
            }
        }

        private void Update()
        {
            if (_environmentActive.Count == numActiveEnvironmentObject) return;
            
            // get random float for x-axis (positive or negative)
            var randomX = Random.value < 0.5f ? Random.Range(positiveMinX, positiveMaxX) : Random.Range(negativeMinX, negativeMaxX);
                
            // get random float for z-axis (only positive)
            var randomZ = Random.Range(positiveMinZ, positiveMaxZ);

            if (Random.value < 0.5f)
                SpawnNewTree(randomX, randomZ);
            else
                SpawnNewRock(randomX, randomZ);
        }

        private void SpawnNewTree(float randomX, float randomZ)
        {
            // get tree from pool into a parent, put him, inside the active list
            // and position it at random position
            _tree = _environmentPoolManager.GetTree();
            _tree.transform.SetParent(parentTransform, false);
            _environmentActive.Add(_tree);
            _tree.transform.position = new Vector3(randomX, 0f, randomZ);
        }

        private void SpawnNewRock(float randomX, float randomZ)
        {
            // get rock from pool into a parent, put him, inside the active list
            // and position it at random position
            _rock = _environmentPoolManager.GetRock();
            _rock.transform.SetParent(parentTransform, false);
            _environmentActive.Add(_rock);
            _rock.transform.position = new Vector3(randomX, 0f, randomZ);
        }

        public void RemoveFromActiveEnvironment(GameObject obj)
        {
            _environmentActive.Remove(obj);
        }
    }
}
