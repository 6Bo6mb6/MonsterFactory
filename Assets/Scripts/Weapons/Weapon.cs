using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] protected float _speed;

    protected Bullet _bullet;

    public virtual void Fire(Vector2 direction, Bullet bulletPrefab, string shooter) 
    {
        SpawnBullet(bulletPrefab, shooter);
        _bullet.MoveBullet(direction, _speed);
    }

    protected void SpawnBullet(Bullet bulletPrefab, string shooter)
    {
        _bullet = Instantiate(bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        _bullet.Shooter = shooter;
    }
}
