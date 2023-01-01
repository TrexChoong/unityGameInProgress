using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject pauseMenuUI;
    public GameObject controlMenuUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(GameIsPause) 
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        controlMenuUI.SetActive(false);
        SettingsMenu.Instance.Panel.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause= true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        
        pauseMenuUI.SetActive(false);
        controlMenuUI.SetActive(true);

    }

    public void Return()
    {
        pauseMenuUI.SetActive(true);
        controlMenuUI.SetActive(false);
    }
}
