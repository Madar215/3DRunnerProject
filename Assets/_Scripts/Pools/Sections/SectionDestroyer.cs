using UnityEngine;

namespace _Scripts.Pools.Sections
{
    public class SectionDestroyer : MonoBehaviour
    {
        private SectionPoolManager _sectionPoolManager;

        private void Awake()
        {
            _sectionPoolManager = GetComponentInParent<SectionPoolManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Section")) return;
            
            _sectionPoolManager.ReturnSectionToPool(other.gameObject);
        }
    }
}
