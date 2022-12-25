using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{

    //teleport
    public GameObject teleportTarget;
    public GameObject thePlayer;
    private void OnTriggerEnter(Collider other)
    {
        
        thePlayer.GetComponent<NavMeshAgent>().enabled = false;
        thePlayer.transform.position = teleportTarget.transform.position;
        thePlayer.GetComponent<NavMeshAgent>().enabled = true;

        gameObject.SetActive(false);
        teleportTarget.SetActive(false);
    }
}
