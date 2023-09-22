using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    [SerializeField] private Score _score;

    private Text _text;

    public void Start()
    {
        _text = GetComponent<Text>();
        _score.ChangeMoney.AddListener(UpdateUi);
    }
  
    private void UpdateUi( int money)
    {
        _text.text = "Score:" + money; 
    }
}
