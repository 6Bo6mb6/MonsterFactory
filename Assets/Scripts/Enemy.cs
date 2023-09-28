using System.Collections;
using UnityEngine;

[RequireComponent(typeof(WalkDirectionGenerator))]
public class Enemy : Person
{   
    [SerializeField] private int _price;

    private Score _score;
    private Person _player;
    private IMovable _generator;
    private BodyCustomizer _bodyCustomizer;
    private Vector2 _direction = Vector2.right;
    private Vector2 _bulletDirection;


    protected override void Die()
    {
        if (_bodyCustomizer.IsDefect)
            _score.Add(_price);
        else
            _score.Subtract(_price);

        gameObject.SetActive(false);
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _score = _player.GetComponent<Score>();
        _bodyCustomizer = GetComponent<BodyCustomizer>();
        _generator = GetComponent<WalkDirectionGenerator>();
    }

    private void Update()
    {
        if (ReachedThePoint())
        {
            SetNewDirection(_generator.GenerateNewDirection(GetRigidbodyPosition()));
        }
    }

    private void FixedUpdate()
    {   
        Walk(_direction);
    }

    public void WakeUp() 
    {
        StartCoroutine(FireThroughTime());
        SetNewDirection(_generator.GenerateNewDirection(GetRigidbodyPosition()));
    }

    public void Sleep()
    {
        StopCoroutine(FireThroughTime());
        SetNewDirection(Vector2.zero);
    }

    private void SetNewDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private IEnumerator FireThroughTime()
    {
        while (true) 
        {
            yield return new WaitForSeconds(2f);
            _bulletDirection = _player.GetRigidbodyPosition() - GetRigidbodyPosition();
            Fire(_bulletDirection.normalized);
        }
    }

    private bool ReachedThePoint() 
    {
        return Mathf.Round(GetRigidbodyPosition().x) == _generator.CurrentPoint.x
                &&
                Mathf.Round(GetRigidbodyPosition().y) == _generator.CurrentPoint.y;
    }
}
