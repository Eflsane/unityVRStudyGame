using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButtonsController.instance.GameStarted += Instance_GameStarted;
    }

    private void Instance_GameStarted()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
