using UnityEngine;

public class Shotgun : Weapon
{
    private int _numberOfBullets = 3;
    private float _rotationAngleStart = 90f;
    private float _rotationAngle = -45f;

    public override void Fire(Vector2 direction, Bullet bulletPrefab , string shooter)
    {
        direction = Quaternion.Euler(0, 0, _rotationAngleStart) * direction;

        for (int i = 0; i < _numberOfBullets; i++) 
        { 
            direction = Quaternion.Euler(0, 0, _rotationAngle) * direction;
            base.Fire(direction, bulletPrefab, shooter);
        }
    }

}
