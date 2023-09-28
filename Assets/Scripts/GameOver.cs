using UnityEngine.Events;
using UnityEngine;
using System;

public class GameOver : MonoBehaviour
{
    [HideInInspector] public UnityEvent ChangeUI;

    public void Lose()
    {
        ChangeUI?.Invoke();
    }
}
