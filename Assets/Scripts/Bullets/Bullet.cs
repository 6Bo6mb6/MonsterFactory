using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet  : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy = 2f;
    [SerializeField] private float _percentDamage = 30f;

    private Rigidbody2D _rb;

    public string Shooter { get; set;}

    public void MoveBullet(Vector2 direction, float speed)
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void Damage(Collider2D collision)
    {
        Health hp = collision.GetComponent<Health>();
        hp.Damage(_percentDamage);
        Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(DestroyThroughTime());
    }

    private IEnumerator DestroyThroughTime()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Person person) && person.ClassName != Shooter)
        {
            Damage(collision);
        }
        else
        {
            Debug.Log(person);
        }
    }
}
