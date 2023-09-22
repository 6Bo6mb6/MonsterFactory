using UnityEngine;

public interface IMovable
{
    Vector2 CurrentPoint { get;}
    Vector2 GenerateNewDirection(Vector2 rbPosition);
}
