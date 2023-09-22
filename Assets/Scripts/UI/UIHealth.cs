using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private Health _hp;

    private Slider _healthBar;

    public void Start()
    {
        _healthBar = GetComponent<Slider>();
        _hp.ÑhangeHealth.AddListener(UpdateUiHealth);
    }

    private void UpdateUiHealth(float health)
    {
        _healthBar.value = health;
    }
}
