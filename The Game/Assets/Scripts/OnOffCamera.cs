using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffCamera : MonoBehaviour
{
    private GameObject cam1;
    private GameObject cam2;
    // Start is called before the first frame update
    void Start()
    {
        cam2 = GameObject.FindGameObjectWithTag("Cam2");
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime >= 11)
        {
            cam1 = GameObject.Find("Cam");
            cam1.SetActive(false);
             cam2.SetActive(true);
        }
      

    }

}
