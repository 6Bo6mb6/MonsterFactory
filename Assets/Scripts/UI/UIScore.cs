using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIScore : MonoBehaviour
{
    [SerializeField] private Score _score;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        _score.Change.AddListener(UpdateUi);
    }
  
    private void UpdateUi( int money)
    {
        _text.text = "Score:" + money; 
    }
}
