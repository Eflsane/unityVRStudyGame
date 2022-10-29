using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseCanvas;

    public bool isGamePaused;
    // Start is called before the first frame update
    void Start()
    {
        isGamePaused = false;

        PlayerControllerMy.instance.OnStartPress += PauseGame;
        PlayerControllerMy.instance.OnTwoPress += GoToMainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        if(isGamePaused)
        {
            Time.timeScale = 1;
            _pauseCanvas.SetActive(false);
            isGamePaused = false;

            return;
        }

        _pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void GoToMainMenu()
    {
        if(isGamePaused)
        {
            Time.timeScale = 1;
            isGamePaused = false;
            SceneManager.LoadScene(0);           
        }
            
    }
}
