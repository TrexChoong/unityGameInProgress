using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Image[] QuestSlots;
    public Text QuestDescription;
    public Transform ObjectivePointer;
    public Transform[] ObjectiveTargets;
    public Sprite m_CompletedQuestSprite;
    public Sprite m_QuestSprite1;
    public Sprite m_QuestSprite2;
    public Sprite m_QuestSprite3;

    private int CurrentQuestLevel = 0;
    
    public void ProgressQuest() {
        if(CurrentQuestLevel < 7)
            CurrentQuestLevel++;
        UpdateQuestProgress(CurrentQuestLevel);
    }

    private void UpdateQuestProgress(int progress) {
        switch (progress) {
            case 1: 
            QuestDescription.text = "Something weird happened, talk to ilama to find out what.";
            break;
            case 2: 
            QuestDescription.text = "Find the spaceship.";
            QuestSlots[0].sprite = m_QuestSprite1;
            break;
            case 3: 
            QuestDescription.text = "Kill cactus bossy.";
            break;
            case 4: 
            QuestDescription.text = "Talk to ilama.";
            QuestSlots[0].sprite = m_CompletedQuestSprite;
            break;
            case 5: 
            QuestDescription.text = "Find legendary rake.";
            QuestSlots[1].sprite = m_QuestSprite2;
            break;
            case 6: 
            QuestDescription.text = "Kill elite cactus bossy.";
            QuestSlots[1].sprite = m_CompletedQuestSprite;
            QuestSlots[2].sprite = m_QuestSprite3;
            break;
            case 7: 
            QuestDescription.text = "Congratulations, you have saved the farm.";
            QuestSlots[2].sprite = m_CompletedQuestSprite;
            break;
            default: 
            QuestDescription.text = "Error loading quest description.";
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
        
    }
}
