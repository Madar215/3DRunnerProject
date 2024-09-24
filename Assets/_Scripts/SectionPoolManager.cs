using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts
{
    public class SectionPoolManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> sectionListPrefab = new();
        [SerializeField] private Transform sectionParent;

        private List<GameObject> _sectionPool = new();

        private GameObject _section;

        private void Awake()
        {
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
                _section = GetRandomSectionFromPool();
                _section.SetActive(true);
                _section.transform.position = new Vector3(0f, 0f, 22f + (50f * i));
            }
        }

        public GameObject GetRandomSectionFromPool()
        {
            int randomIndex;

            while(true)
            {
                randomIndex = Random.Range(0, _sectionPool.Count - 1);
                
                if (!_sectionPool[randomIndex].activeInHierarchy)
                    break;
            }
            
            return _sectionPool[randomIndex];
        }
        
    }
}
