using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private int _money;
    [HideInInspector] public UnityEvent<int> ChangeMoney;

    public void Add(int money) 
    {
        if(money > 0)
        _money += money;
        ChangeMoney?.Invoke(_money);
    }
    
    public void Subtract(int money)
    {
        if (money > 0)
            _money -= money;
        ChangeMoney?.Invoke(_money);
    }
}
