using UnityEngine;

public class Player : Person
{
    [SerializeField]private GameOver _gameOver;

    protected override void Die()
    {
        _gameOver.Lose();
    }
  
}
