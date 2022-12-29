using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceCondition : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        VolcanoHints.message = "Defeat all enemy on the volcano to open the fence!";
        VolcanoHints.textOn = true;
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
