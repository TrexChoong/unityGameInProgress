using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class UIManager : MonoBehaviour
{

    private string levelToLoad;
    public AudioClip beep;

    void playBtnSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = beep;
        audio.Play();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
    }

    public void PlayBtnClicked()
    {
        levelToLoad = "Island Level";
        playBtnSound();
        StartCoroutine(Wait());
        SceneManager.LoadScene(levelToLoad);
    }

    public void InsBtnClicked()
    {
        levelToLoad = "Instructions";
        playBtnSound();
        StartCoroutine(Wait());
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitBtnClicked()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {

        } 
        else
        {
            levelToLoad= "";
            playBtnSound();
            StartCoroutine(Wait());
            Application.Quit();
            Debug.Log("This part works!");
        }

    }

    public void InsBackBtnClicked()
    {
        levelToLoad = "MenuScene";
        playBtnSound();
        StartCoroutine(Wait());
        SceneManager.LoadScene(levelToLoad);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
