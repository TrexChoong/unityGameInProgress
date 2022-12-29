using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VolcanoHints : MonoBehaviour
{
    public static bool textOn = false;
    public static string message;
    private float timer = 0.0f;
    TMP_Text Hint;
    // Start is called before the first frame update
    void Start()
    {
        Hint = GetComponent<TMP_Text>();
        timer = 0.0f;
        textOn = false;
        Hint.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (textOn)
        {
            Hint.enabled = true;
            Hint.text = message;
            timer += Time.deltaTime;
        }

        if (timer >= 5)
        {
            textOn = false;
            Hint.enabled = false;
            timer = 0.0f;
        }
    }
}
