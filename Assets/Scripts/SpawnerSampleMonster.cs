using UnityEngine;
using Object = UnityEngine.Object;
public class SpawnerSampleMonster 
{
    public void Spawn(BodyCustomizer prefab , Transform spawnPoint) 
    {
        BodyCustomizer enemy = Object.Instantiate(prefab, spawnPoint);
        IVisible visibleEnemy = enemy;
        visibleEnemy.GoOneOrderHigherInLayer(spawnPoint.parent.GetComponent<SpriteRenderer>());
        enemy.GetComponent<Enemy>().Sleep();
    }
}
