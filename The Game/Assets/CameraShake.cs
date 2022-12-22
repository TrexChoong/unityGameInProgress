using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool start = false;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {
        Vector3 oriPos = transform.position;

        float timer = 0.0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.position = oriPos + UnityEngine.Random.insideUnitSphere;

            yield return null;
        }
        transform.position = oriPos;
    }
}
