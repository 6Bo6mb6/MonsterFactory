using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]

public abstract class Person : MonoBehaviour
{
    public Weapon _currentWeapon;
    
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] protected float _speed = 10f;
    
    protected Rigidbody2D _rb;
    private Health _hp;

    public string ClassName { get; private set; }
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _hp = GetComponent<Health>();

        _hp.PersonDie.AddListener(Die);

        ClassName = GetType().Name;
    }

    public virtual void Walk(Vector2 direction) 
    {
        _rb.MovePosition(_rb.position + direction * _speed * Time.fixedDeltaTime);
    }

    public void Fire(Vector2 direction)
    {
        _currentWeapon.Fire(direction, _bulletPrefab, ClassName);
    }

    public Vector2 GetRigidbodyPosition() 
    {
        return _rb.position;
    }

    protected abstract void Die();

}
