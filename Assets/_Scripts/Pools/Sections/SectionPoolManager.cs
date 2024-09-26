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
            for (int i = 0; i < 2; i++)
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
            
            // get random section, active it, add it to active section list and position it.
            _section = GetRandomSectionFromPool();
            _section.SetActive(true);
            _activeSections.Add(_section);
            _section.transform.position = new Vector3(0f, 0f, 72f);
        }

        public GameObject GetRandomSectionFromPool()
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
