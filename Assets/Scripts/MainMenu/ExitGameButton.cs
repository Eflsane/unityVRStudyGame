using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButtonsController.instance.GameEnded += Instance_GameEnded;
    }

    private void Instance_GameEnded()
    {
        Application.Quit(0);
    }
}
