using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class CoconutThrow : MonoBehaviour
{
    public AudioClip throwSound;
    public GameObject CoconutObject;
    public float ThrowForce;
    static public bool canThrow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1") && canThrow)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip= throwSound;
            audio.Play();
            GameObject temp = Instantiate(CoconutObject, transform.position, transform.rotation);
            temp.name= "Coconut";
            if (temp.GetComponent<Rigidbody>() == null) 
            {
                Debug.Log("Component Missing!!!!");
                temp.AddComponent<Rigidbody>();
                Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), temp.GetComponent<Collider>(), true);
            }
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(new Vector3(0,0,ThrowForce));
        }
    }
}
