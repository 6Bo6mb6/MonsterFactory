using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _offset = 0f;
    [SerializeField] private int _speed;

    private Rigidbody2D _rb;
   

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        _rb.MovePosition(_rb.position + Vector2.right * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PersonalScreeningScanner scanner))
        {
            TeleportToPoint();
        }
    }
    private void TeleportToPoint()
    {
        _rb.position = new Vector2(_point.position.x - _offset, _rb.position.y);
    }

}
