using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Pools.Sections
{
    public class SectionPoolManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> sectionListPrefab = new();
        [SerializeField] private Transform sectionParent;
        [SerializeField] private int maxActiveSections = 2;

        private List<GameObject> _sectionPool = new();
        private List<GameObject> _activeSections = new();

        private GameObject _section;

        private void Awake()
        {
            // instantiate every prefab and add it to section pool.
            foreach (var sectionPrefab in sectionListPrefab)
            {
                _section = Instantiate(sectionPrefab, sectionParent, false);
                _sectionPool.Add(_section);
                _section.SetActive(false);
            }
        }

        private void Start()
        {
            // activate the first section which is a shot one for the start of the game.
            _section = _sectionPool[0];
            _section.SetActive(true);
            _activeSections.Add(_section);
            _section.transform.position = new Vector3(0f, 0f, 22f);
            
            for (int i = 1; i < maxActiveSections - 1; i++)
            {
                // get random section, active it, add it to active section list and position it.
                _section = GetRandomSectionFromPool();
                _section.SetActive(true);
                _activeSections.Add(_section);
                _section.transform.position = new Vector3(0f, 0f, 22f + (50f * i));
            }
        }

        private void Update()
        {
            if (_activeSections.Count == maxActiveSections) return;
            
            // calculate the last section's position, get random section, active it,
            //  add it to the active section list and position it.
            var lastSectionPosZ = _section.transform.position.z;
            _section = GetRandomSectionFromPool();
            _section.SetActive(true);
            _activeSections.Add(_section);
            _section.transform.position = new Vector3(0f, 0f, lastSectionPosZ + 50);
        }

        private GameObject GetRandomSectionFromPool()
        {
            int randomIndex;

            while(true)
            {
                randomIndex = Random.Range(0, _sectionPool.Count);
                
                // break from loop only if the random section is not active in scene.
                if (!_sectionPool[randomIndex].activeInHierarchy)
                    break;
            }
            
            return _sectionPool[randomIndex];
        }

        public void ReturnSectionToPool(GameObject obj)
        {
            obj.SetActive(false);
            _activeSections.Remove(obj);
        }
        
    }
}
