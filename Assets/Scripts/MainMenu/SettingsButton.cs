using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButtonsController.instance.GameSettted += Instance_GameSettted;
    }

    private void Instance_GameSettted()
    {
        
    }
}
