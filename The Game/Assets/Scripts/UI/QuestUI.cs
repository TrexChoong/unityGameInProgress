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
    public Image m_CompletedQuestSprite;
    public Image m_QuestSprite1;
    public Image m_QuestSprite2;
    public Image m_QuestSprite3;
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
