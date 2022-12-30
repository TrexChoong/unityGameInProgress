using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace CreatorKitCodeInternal
{
    public class Teleport : MonoBehaviour
    {

        //teleport
        public GameObject teleportTarget;
        public GameObject thePlayer;
        public QuestUI questInstance;
    private void OnTriggerEnter(Collider other)
        {
            if (questInstance.CurrentQuestLevel == 5  && gameObject.name == "Teleporter" || questInstance.CurrentQuestLevel == 6)
            {
                thePlayer.GetComponent<NavMeshAgent>().enabled = false;
                thePlayer.transform.position = teleportTarget.transform.position;
                thePlayer.GetComponent<NavMeshAgent>().enabled = true;

                questInstance.ProgressQuest();
            }
            else if (questInstance.CurrentQuestLevel == 8 && gameObject.name == "Teleporter2")
            {
                thePlayer.GetComponent<NavMeshAgent>().enabled = false;
                thePlayer.transform.position = teleportTarget.transform.position;
                thePlayer.GetComponent<NavMeshAgent>().enabled = true;

                gameObject.SetActive(false);
                teleportTarget.SetActive(false);
                questInstance.ProgressQuest();
            }
        }
    }
}