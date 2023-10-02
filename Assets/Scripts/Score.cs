using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private int _score;
    [HideInInspector] public UnityEvent<int> Change;

    public void Add(int score) 
    {
        if(score > 0)
            _score += score;
        Change?.Invoke(_score);
    }
    
    public void Subtract(int money)
    {
        if (money > 0)
            _score -= money;
        Change?.Invoke(_score);
    }
}
