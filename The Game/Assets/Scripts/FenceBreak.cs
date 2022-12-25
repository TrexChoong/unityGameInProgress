using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FenceBreak : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy1.GetComponent<NavMeshAgent>() == false &&
            enemy2.GetComponent<NavMeshAgent>() == false &&
            enemy3.GetComponent<NavMeshAgent>() == false &&
            enemy4.GetComponent<NavMeshAgent>() == false)
        {
            Destroy(gameObject);
        }
    }
}
