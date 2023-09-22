using UnityEngine;
using UnityEngine.UI;

public class UIReputation : MonoBehaviour
{
    [SerializeField] private Health _reputation;

    private Slider _bar;

    public void Start()
    {
        _bar = GetComponent<Slider>();
        _reputation.ÑhangeHealth.AddListener(UpdateUiHealth);
    }

    private void UpdateUiHealth(float health)
    {

        _bar.value = 100f - health;
    }
}
