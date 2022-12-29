using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossWall : MonoBehaviour
{
    public GameObject boss;
    public GameObject teleportTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportTarget.activeSelf == false)
            Destroy(gameObject);

        if (gameObject.activeSelf == true)
            boss.GetComponent<NavMeshAgent>().enabled = false;

        boss.GetComponent<NavMeshAgent>().enabled = true;
    }
}
