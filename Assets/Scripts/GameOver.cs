using UnityEngine.Events;
using UnityEngine;
using System;

public class GameOver : MonoBehaviour
{
    [HideInInspector] public UnityEvent ÑhangeUI;

    public void Lose()
    {
        ÑhangeUI?.Invoke();
    }
}
