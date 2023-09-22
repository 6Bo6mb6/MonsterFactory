using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Transform _normalMonsterSpawnPoint;
    [SerializeField] private BodyCustomizer _monsterPrefab;
    [SerializeField] private float _timeToSpawn = 1f;
    [SerializeField] private PoolsKeeper _pool;

    private BodyCustomizer _defevtiveMonster;
    private SpawnerSampleMonster _spawnerSample;

    public void Start()
    {
        _spawnerSample = new SpawnerSampleMonster();
        _spawnerSample.Spawn(_monsterPrefab, _normalMonsterSpawnPoint);
        StartCoroutine(SpawnThroughTime());
    }

    public void Spawn() 
    {
        _defevtiveMonster = _pool.GetFreeEnemy(_monsterPrefab, _spawnPoints);
        if (Random.Range(0, 6) == 2)
            _defevtiveMonster.CreatingDefects();
    }

    private IEnumerator SpawnThroughTime()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_timeToSpawn); 
        }
    }


}
