using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public float music = 0f;
    public float game = 0f;
    public float ambience = 0f;
    public float effect = 0f;

    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }
    public void Update()
    {
        SettingsMenu.Instance.audioMixer.GetFloat("music", out music);
        SettingsMenu.Instance.audioMixer.GetFloat("game", out game);
        SettingsMenu.Instance.audioMixer.GetFloat("ambience", out ambience);
        SettingsMenu.Instance.audioMixer.GetFloat("effect", out effect);
    }

    public void SetAudio()
    {
        
    }

}
