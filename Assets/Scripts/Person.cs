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
    
    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _hp = GetComponent<Health>();

        _hp.PersonDie.AddListener(Die);

        ClassName = GetClassName();
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
        Vector2 rbPosition = _rb.position;
        return rbPosition;
    }

    protected abstract void Die();

    private string GetClassName() 
    {
        string className = ToString();
        className = className.Substring(className.IndexOf("(") + 1);
        className = className.Remove(className.Length - 1);
        return className;
    }

}
