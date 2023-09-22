using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealth, _maxHealth;

    [HideInInspector] public UnityEvent PersonDie;
    [HideInInspector] public UnityEvent<float> ÑhangeHealth;
    
    public void Healing(float Percent)
    {
        if (Percent > 0 && Percent <= 100)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + _maxHealth * Percent / 100f, 0, 100);
        }

        ÑhangeHealth?.Invoke(GetCurrentHealthPercent());
    }

    public void Damage(float Percent)
    {
        if (Percent > 0 && Percent <= 100)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - _maxHealth * Percent / 100f, 0, 100);
            Debug.Log(_currentHealth);
        }

        ÑhangeHealth?.Invoke(GetCurrentHealthPercent());

        if (_currentHealth == 0)
        {
            PersonDie?.Invoke();
        }

    }

    private float GetCurrentHealthPercent() 
    {   
        float Percent;
        Percent = _currentHealth * 100 / _maxHealth;
        return Percent;
    }

    private void Awake()
    {
        _currentHealth = Mathf.Clamp(_currentHealth , 1, _maxHealth);
    }

}
