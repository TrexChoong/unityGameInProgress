using System.Collections;
using System.Collections.Generic;
using CreatorKitCodeInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
namespace CreatorKitCodeInternal
{
    public class QuestUI : MonoBehaviour
    {
        public static QuestUI Instance { get; private set; }
        public GameObject boss1;
        public GameObject boss2;
        public Image[] QuestSlots;
        public Text QuestDescription;
        public Transform ObjectivePointer;
        public Transform[] ObjectiveTargets;
        public Sprite m_CompletedQuestSprite;
        public Sprite m_QuestSprite1;
        public Sprite m_QuestSprite2;
        public Sprite m_QuestSprite3;
        public GameObject buttonHide;
        public int CurrentQuestLevel = 1;
        public bool NPCStart1 = false;
        public FenceBreak quest6;
        public void ProgressQuest()
        {
            if (CurrentQuestLevel < 10)
                CurrentQuestLevel++;
            UpdateQuestProgress(CurrentQuestLevel);
        }

        private void UpdateQuestProgress(int progress)
        {
            switch (progress)
            {
                case 1:
                    QuestDescription.text = "Something weird happened, talk to ilama to find out what.";
                    UISystem.Instance.UpdateNavigationTarget(ObjectiveTargets[0]);
                    NPCStart1 = true;
                    break;
                case 2:
                    QuestDescription.text = "Find the spaceship.";
                    QuestSlots[0].sprite = m_QuestSprite1;
                    UISystem.Instance.UpdateNavigationTarget(ObjectiveTargets[1]);
                    NPCStart1 = false;
                    break;
                case 3:
                    QuestDescription.text = "Kill cactus bossy. (Hints to make it easier, wear the weapon u just got!)";
                    QuestSlots[0].sprite = m_QuestSprite1;
                    UISystem.Instance.UpdateNavigationTarget(ObjectiveTargets[2]);
                    NPCStart1 = false;
                    break;
                case 4:
                    QuestDescription.text = "Talk to ilama.";
                    QuestSlots[0].sprite = m_CompletedQuestSprite;
                    UISystem.Instance.UpdateNavigationTarget(ObjectiveTargets[3]);
                    NPCStart1 = true;
                    break;
                case 5:
                    QuestDescription.text = "Find legendary rake.";
                    QuestSlots[1].sprite = m_QuestSprite2;
                    UISystem.Instance.UpdateNavigationTarget(ObjectiveTargets[4]);
                    NPCStart1 = false;
                    break;
                case 6:
                    
                    QuestDescription.text = "Kill all the enemy (" + quest6.enemyCount.ToString() + "/4)";
                    QuestSlots[1].sprite = m_QuestSprite2;
                    UISystem.Instance.UpdateNavigationTarget(ObjectiveTargets[5]);
                    NPCStart1 = false;
                    break;
                case 7:
                    QuestDescription.text = "Find legendary rake.";
                    QuestSlots[1].sprite = m_QuestSprite2;
                    UISystem.Instance.UpdateNavigationTarget(ObjectiveTargets[6]);
                    NPCStart1 = false;
                    break;
                case 8:
                    QuestDescription.text = "Go back and kill the final boss.";
                    QuestSlots[1].sprite = m_QuestSprite2;
                    UISystem.Instance.UpdateNavigationTarget(ObjectiveTargets[7]);
                    NPCStart1 = false;
                    break;
                case 9:
                    QuestDescription.text = "Kill elite cactus bossy. (Hints to make it easier, wear the legendary rake u just got!)";
                    QuestSlots[1].sprite = m_CompletedQuestSprite;
                    QuestSlots[2].sprite = m_QuestSprite3;
                    UISystem.Instance.UpdateNavigationTarget(ObjectiveTargets[8]);
                    NPCStart1 = false;
                    break;
                case 10:
                    QuestDescription.text = "Congratulations, you have saved the farm! Now go back to ilama.";
                    QuestSlots[2].sprite = m_CompletedQuestSprite;
                    UISystem.Instance.UpdateNavigationTarget(ObjectiveTargets[9]);
                    NPCStart1 = true;
                    break;
                default:
                    QuestDescription.text = "Error loading quest description.";
                    NPCStart1 = false;
                    break;
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            
            QuestDescription.text = "Welcome to our game, this is the beginning of your quest.";
            // for (int i = 0; i < QuestSlots.Length; ++i)
            // {
            //     QuestSlots[i].targetGraphic(m_LockedQuestSprite);
            // }

        }

        // Update is called once per frame
        void Update()
        {
            UpdateQuestProgress(CurrentQuestLevel);
            if (NPCStart1)
            {
                Destroy(buttonHide);
            }
            if (boss1.GetComponent<NavMeshAgent>() == false)
            {
                if(CurrentQuestLevel == 3)
                {
                    ProgressQuest();
                }
            }
            if (boss2.GetComponent<NavMeshAgent>() == false)
            {
                if (CurrentQuestLevel == 9)
                {
                    ProgressQuest();
                }
            }
        }
    }
}
