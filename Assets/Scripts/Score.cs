using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private int _score;
    [HideInInspector] public UnityEvent<int> ChangeMoney;

    public void Add(int score) 
    {
        if(score > 0)
            _score += score;
        ChangeMoney?.Invoke(_score);
    }
    
    public void Subtract(int money)
    {
        if (money > 0)
            _score -= money;
        ChangeMoney?.Invoke(_score);
    }
}
