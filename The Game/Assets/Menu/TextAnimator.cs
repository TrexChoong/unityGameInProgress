using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimator : MonoBehaviour
{
    public float startPosition = -800.0f;
    public float endPosition = 500.0f;
    public float speed = 0.5f;
    private float startTime;
    private float posX;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        posX = Mathf.Lerp(startPosition, endPosition, (Time.time - startTime) * speed);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
