using UnityEngine;
using UnityEngine.Pool;

namespace _Scripts.Pools.Obstacles
{
    public class EnvironmentPoolManager : MonoBehaviour
    {
        [SerializeField] private int poolDefaultSize = 5;
        [SerializeField] private int poolMaxSize = 10;
        
        public GameObject treeObject;
        public GameObject rockObject;
        
        private ObjectPool<GameObject> _treePool;
        private ObjectPool<GameObject> _rockPool;
        private void Awake()
        {
            _treePool = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(treeObject),
                actionOnGet: obj => obj.SetActive(true),
                actionOnRelease: obj => obj.SetActive(false),
                actionOnDestroy: Destroy,
                collectionCheck: false,
                poolDefaultSize,
                poolMaxSize
                );
            
            _rockPool = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(rockObject),
                actionOnGet: obj => obj.SetActive(true),
                actionOnRelease: obj => obj.SetActive(false),
                actionOnDestroy: Destroy,
                collectionCheck: false,
                poolDefaultSize,
                poolMaxSize
            );
        }

        public GameObject GetTree()
        {
            return _treePool.Get();
        }

        public void ReleaseTree(GameObject tree)
        {
            _treePool.Release(tree);
        }
        
        public GameObject GetRock()
        {
            return _rockPool.Get();
        }

        public void ReleaseRock(GameObject rock)
        {
            _rockPool.Release(rock);
        }
    }
}
