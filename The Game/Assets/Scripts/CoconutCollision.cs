using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoconutCollision : MonoBehaviour
{
    public GameObject targetRoot;
    private bool beenHit = false;
    private float timer = 0.0f;
    public AudioClip hitSound;
    public AudioClip resetSound;

    private void OnCollisionEnter(Collision theObject)
    {
        if (beenHit == false && theObject.gameObject.name == "Coconut")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip= hitSound;
            audio.Play();
            targetRoot.GetComponent<Animation>().Play("down");
            beenHit= true;
            CoconutWin.targets++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beenHit)
        {
            timer += Time.deltaTime;
        }
        if (timer > 3)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip= resetSound;
            audio.Play();
            targetRoot.GetComponent<Animation>().Play("up");
            beenHit= false;
            timer = 0.0f;
            CoconutWin.targets--;
        }
    }
}
