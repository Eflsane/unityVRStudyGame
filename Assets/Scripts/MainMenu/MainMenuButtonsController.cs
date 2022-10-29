using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonsController : MonoBehaviour
{
    public static MainMenuButtonsController instance;

    public event Action GameStarted = () => { };
    public event Action GameSettted = () => { };
    public event Action GameEnded = () => { };

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
    }
    private void Start()
    {
        
    }

    public void StartGame()
    {
        GameStarted?.Invoke();
    }

    public void Settings()
    {
        GameSettted?.Invoke();
    }

    public void ExitGame()
    {
        GameEnded?.Invoke();
    }
}
