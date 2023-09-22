using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    private int _numberOfBullets = 3;
    private float _interval = 0.1f;
    private Vector2 _direction;
    private Bullet _bulletPrefab;
    private string _shooter;
    private bool _endOfShooting = true;

    public override void Fire(Vector2 direction, Bullet bulletPrefab, string shooter)
    {
        if (_endOfShooting)
        {
            _direction = direction;
            _bulletPrefab = bulletPrefab;
            _shooter = shooter;
            StartCoroutine(ShootThroughTime());
        }
    }

    private IEnumerator ShootThroughTime()
    {
        _endOfShooting = false;
        for (int i = 0; i < _numberOfBullets; i++)
        {
            base.Fire(_direction, _bulletPrefab, _shooter);
            yield return new WaitForSeconds(_interval);
        }
        _endOfShooting = true;
    }

}
