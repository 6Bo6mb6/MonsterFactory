using UnityEngine;

public class PoolsKeeper : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private bool _autoExpand = false;
    //[SerializeField] private Enemy _prefabEnemy;

    private Pool<BodyCustomizer> _pool;

    public BodyCustomizer GetFreeEnemy(BodyCustomizer prefabEnemy, Transform spawnPositon) 
    {
        if (_pool == null) 
            ÑreateANewPool(prefabEnemy);

        BodyCustomizer enemy = _pool.GetFreeElement();
        enemy.transform.position = new Vector3(spawnPositon.position.x, spawnPositon.position.y, spawnPositon.position.z);
        return enemy;
    }

    private void ÑreateANewPool(BodyCustomizer prefabEnemy) 
    {
            _pool = new Pool<BodyCustomizer>(prefabEnemy, _poolCount, transform);
            _pool.AutoExpand = _autoExpand;
    }
}
