using UnityEngine.Events;
using UnityEngine;
using System;

public class GameOver : MonoBehaviour
{
    [HideInInspector] public UnityEvent �hangeUI;

    public void Lose()
    {
        �hangeUI?.Invoke();
    }
}
