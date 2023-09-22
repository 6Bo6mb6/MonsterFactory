using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField]private GameObject _panel;
    [SerializeField] private GameOver _gameOver;

    public void Start()
    {
        _gameOver.ÑhangeUI.AddListener(UpdateUI); 
    }

    private void UpdateUI()
    {
        _panel.SetActive(true);
    }
}
