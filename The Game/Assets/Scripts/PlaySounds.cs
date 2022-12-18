using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySounds : MonoBehaviour {

    public AudioClip myClip;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = myClip;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
