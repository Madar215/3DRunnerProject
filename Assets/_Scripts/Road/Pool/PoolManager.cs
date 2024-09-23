using UnityEngine;
using UnityEngine.Pool;

namespace _Scripts.Road.Pool
{
    public class PoolManager : MonoBehaviour
    {
        public int poolDefaultSize = 5;
        public int poolMaxSize = 10;

        public GameObject objectPrefab;

        private ObjectPool<GameObject> _pool;
        
        private void Awake()
        {
            _pool = new ObjectPool<GameObject>(
                CreatePooledObject,
                OnTakeFromPool,
                OnReturnedToPool,
                OnDestroyObject,
                true,
                poolDefaultSize,
                poolMaxSize
                );
        }

        private GameObject CreatePooledObject()
        {
            return Instantiate(objectPrefab);
        }

        private void OnTakeFromPool(GameObject obj)
        {
            obj.SetActive(true);
        }

        private void OnReturnedToPool(GameObject obj)
        {
            obj.SetActive(false);
        }

        private void OnDestroyObject(GameObject obj)
        {
            Destroy(obj);
        }

        public GameObject GetObjectFromPool()
        {
            return _pool.Get();
        }

        public void ReturnObjectToPool(GameObject obj)
        {
            _pool.Release(obj);
        }
    }
}
