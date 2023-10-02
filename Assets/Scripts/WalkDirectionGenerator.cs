using UnityEngine;

public class WalkDirectionGenerator :  IMovable
{

    private Vector2 _areaMovement, _currentPoint;
    private Vector2 _direction, _normalizedDirection;

    public Vector2 CurrentPoint { get;  private set; }
    
    private WalkDirectionGenerator() 
    {
        _areaMovement.y = Camera.main.orthographicSize;
        _areaMovement.x = _areaMovement.y * Screen.width / Screen.height;
    }

    public Vector2 GenerateNewDirection(Vector2 rbPosition)  
    {
        _currentPoint.x = Mathf.Round(Random.Range(-_areaMovement.x, _areaMovement.x)); 
        _currentPoint.y = Mathf.Round(Random.Range(-_areaMovement.y, _areaMovement.y));
        CurrentPoint = _currentPoint;
        _direction = _currentPoint - rbPosition;
        _normalizedDirection = _direction.normalized;
        return _normalizedDirection;
    }

    
}
