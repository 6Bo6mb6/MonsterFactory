using UnityEngine;
using UnityEngine.UI;

public class UIReputation : MonoBehaviour
{
    [SerializeField] private Health _reputation;

    private Slider _bar;
    private const float _maxReputationPercent = 100f; 

    private  void Start()
    {
        _bar = GetComponent<Slider>();
        _reputation.ChangeHealth.AddListener(UpdateUiHealth);
    }

    private void UpdateUiHealth(float health)
    {
        _bar.value = _maxReputationPercent - health;
    }
}
