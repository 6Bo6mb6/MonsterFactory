using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealth, _maxHealth;

    [HideInInspector] public UnityEvent PersonDie;
    [HideInInspector] public UnityEvent<float> ChangeHealth;

    private void Awake()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 1f, _maxHealth);
    }

    public void Healing(float Percent)
    {
        if (Percent > 0f && Percent <= 100f)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + _maxHealth * Percent / 100f, 0, 100);
        }

        ChangeHealth?.Invoke(GetCurrentHealthPercent());
    }

    public void Damage(float Percent)
    {
        if (Percent > 0f && Percent <= 100f)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - _maxHealth * Percent / 100f, 0f, 100f);
            Debug.Log(_currentHealth);
        }

        ChangeHealth?.Invoke(GetCurrentHealthPercent());

        if (_currentHealth == 0f)
        {
            PersonDie?.Invoke();
        }

    }

    private float GetCurrentHealthPercent() 
    {   
        return _currentHealth * 100f / _maxHealth;
    }

}
