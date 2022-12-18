using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class PlayerCollisions : MonoBehaviour
{
    //Door
    private bool doorIsOpen = false;
    private float doorTimer = 0.0f;
    private GameObject currentDoor;
    public float doorOpenTime = 3.0f;
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;

    //Battery
    public AudioClip batteryCollect;

    //Match
    private bool haveMatches = false;
    public GameObject matchGUI;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5.0f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject crosshairObj = GameObject.Find("Crosshair");
        RawImage crosshair = crosshairObj.GetComponent<RawImage>(); 
        if (hit.collider == GameObject.Find("mat").GetComponent<Collider>())
        {
            crosshair.enabled = true;
            CoconutThrow.canThrow = true;
            TextHints.textOn = true;
            TextHints.message = "Knock down all 3 at once to win a battery!";
        }
        else
        {
            crosshair.enabled = false;
            CoconutThrow.canThrow = false;
        }

        if (hit.collider.gameObject == GameObject.Find("campfire"))
        {
            if (haveMatches)
            {
                haveMatches = false;
                lightFire();
            }
            else
            {
                TextHints.textOn = true;
                TextHints.message = "I'll need some matches to light this camp fire..";
            }
        }
    }

    void Door(AudioClip aClip, bool openCheck, string animName, GameObject thisDoor)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = aClip;
        audio.Play();
        doorIsOpen = openCheck;
        //thisDoor.transform.parent.GetComponent<Animation>().Play(animName);
        thisDoor.transform.parent.GetComponent<Animator>().SetBool("collided", openCheck);
    }

    void lightFire()
    {
        GameObject campfire;
        GameObject flame;
        GameObject smoke;

        campfire = GameObject.Find("campfire");
        campfire.GetComponent<AudioSource>().Play();

        flame = GameObject.Find("FireSystem");
        flame.GetComponent<ParticleSystem>().Play();

        smoke = GameObject.Find("SmokeSystem");
        smoke.GetComponent<ParticleSystem>().Play();

        Destroy(GameObject.FindWithTag("matchGUI"));

        TextHints.textOn = true;
        TextHints.message = "You Lit the Fire, you'll survive, well done!";
        StartCoroutine(Wait());
        SceneManager.LoadScene("MenuScene");
    }

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "battery")
        {
            Debug.Log("b");
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = batteryCollect;
            audio.Play();
            BatteryCollect.charge++;
            Destroy(collisionInfo.gameObject);
        }
        if (collisionInfo.gameObject.name == "matchbox")
        {
            Debug.Log("hello");
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = batteryCollect;
            audio.Play();
            Destroy(collisionInfo.gameObject);
            haveMatches= true;
            Instantiate(matchGUI, new Vector3(45.0f, 50.0f, 0.0f), transform.rotation, GameObject.Find("Canvas").transform);
            matchGUI.name = "matchGUI";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Door
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,out hit, 5.0f))
        {
            if (hit.collider.gameObject.tag == "outpostDoor" && doorIsOpen == false && BatteryCollect.charge >= 4)
            {
                currentDoor = hit.collider.gameObject;
                Door(doorOpenSound, true, "dooropen", currentDoor);
                GameObject.FindWithTag("BatteryGUI").GetComponent<RawImage>().enabled = false;
            }
            else if (hit.collider.gameObject.tag == "outpostDoor" && doorIsOpen == false && BatteryCollect.charge < 4)
            {
                TextHints.message = "The door seems to need more power!";
                TextHints.textOn = true;
                GameObject.FindWithTag("BatteryGUI").GetComponent<RawImage>().enabled = true;
            }
        }
        if (doorIsOpen)
        {
            doorTimer += Time.deltaTime;

            if (doorTimer > doorOpenTime)
            {
                Door(doorShutSound, false, "doorshut", currentDoor);
                doorTimer = 0.0f;
            }
        }
    }
}
