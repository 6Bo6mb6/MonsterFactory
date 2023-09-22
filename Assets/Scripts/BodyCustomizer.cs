using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BodyCustomizer : MonoBehaviour, IVisible
{
    [SerializeField] private List<GameObject> _details;
    [SerializeField] private Transform _detailsParent;
    [SerializeField] private float _reputationDamage;
    public bool IsDefect { get; private set; } = false;
    public float ReputationDamage => _reputationDamage;

    private void Awake()
    {
        foreach (Transform child in _detailsParent)
        {
            _details.Add(child.gameObject);
        }
    }

    private void OnDisable()
    {
        ReturnToNormal();
    }

    public void CreatingDefects()
    {
        int detailIndex = Random.Range(0, _details.Count);
        SetStateDetailByIndex(detailIndex);
    }

    void IVisible.GoOneOrderHigherInLayer(SpriteRenderer renderer)
    {
        foreach (Transform child in _detailsParent)
        {
            SpriteRenderer detail = child.GetComponent<SpriteRenderer>();
            detail.sortingOrder = renderer.sortingOrder + 1;
        }
    }

    private  void ReturnToNormal() 
    {
        foreach (GameObject detail in _details)
        {
            detail.SetActive(true);
        }
        IsDefect = false;
    }

    private void SetStateDetailByIndex(int index)
    {
        GameObject detail = _details.ElementAt(index);
        detail.SetActive(!detail.activeSelf);
        IsDefect = true;
    }

    
}
