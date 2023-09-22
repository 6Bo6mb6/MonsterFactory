using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Person _player;
    [SerializeField] private Camera _camera;

    private Vector2 _directionMovement ,_mousePos ,_directionBullet;
    
    private void Update()
    {
        _directionMovement.x = Input.GetAxisRaw("Horizontal");
        _directionMovement.y = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButtonDown("Fire1")) 
        {
            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _directionBullet = _mousePos - _player.GetRigidbodyPosition();
            _player.Fire(_directionBullet.normalized);
        }
    }

    private void FixedUpdate()
    {
        _player.Walk(_directionMovement);
    }
}
