using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace CreatorKitCodeInternal
{
    public class FenceBreak : MonoBehaviour
    {
        public GameObject enemy1;
        public GameObject enemy2;
        public GameObject enemy3;
        public GameObject enemy4;
        public float enemyCount;
        public QuestUI questInstance;
        private bool count1 = false;
        private bool count2 = false;
        private bool count3 = false;
        private bool count4 = false;
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
                if(questInstance.CurrentQuestLevel == 6)
                {
                    questInstance.ProgressQuest();
                }
                
            }
            else
            {
                if (enemy1.GetComponent<NavMeshAgent>() == false && !count1)
                {
                    enemyCount++;
                    count1 = true;
                }
                if (enemy2.GetComponent<NavMeshAgent>() == false && !count2)
                {
                    enemyCount++;
                    count2 = true;
                }
                if (enemy3.GetComponent<NavMeshAgent>() == false && !count3)
                {
                    enemyCount++;
                    count3 = true;
                }
                if (enemy4.GetComponent<NavMeshAgent>() == false && !count4)
                {
                    enemyCount++;
                    count4 = true;
                }
            }

        }
    }
}
