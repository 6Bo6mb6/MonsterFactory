using UnityEngine;

public class PersonalScreeningScanner : MonoBehaviour
{
    [SerializeField] private Health _hp;
    [SerializeField] private GameOver _gameOver;

    private Transform _transform;
    private Vector2 _cameraArea;
    private float _offset = 0.6f;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        SetPositionExit();
        _hp.PersonDie.AddListener(GameOver);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BodyCustomizer monster))
        {
            if (monster.IsDefect)
                _hp.Damage(monster.ReputationDamage);

            monster.gameObject.SetActive(false);
        }
    }

    private void SetPositionExit() 
    {
        _cameraArea.y = Camera.main.orthographicSize;
        _cameraArea.x = _cameraArea.y * Screen.width / Screen.height;
        _transform.transform.position = new Vector3(_cameraArea.x + _offset, _transform.position.y, _transform.position.z);
    }

    private void GameOver() 
    {
        _gameOver.Lose();
    }

}
