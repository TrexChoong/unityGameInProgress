using System.Collections;
using System.Collections.Generic;
using CreatorKitCode;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

namespace CreatorKitCodeInternal 
{
    /// <summary>
    /// Main class that handle the Game UI (health, open/close inventory)
    /// </summary>
    public class UISystem : MonoBehaviour
    {
        public static UISystem Instance { get; private set; }
    
        [Header("Player")]
        public CharacterControl PlayerCharacter;
        public Slider PlayerHealthSlider;
        public Text MaxHealth;
        public Text CurrentHealth;
        public EffectIconUI[] TimedModifierIcones;
        public Text StatsText;

        [Header("Enemy")]
        public Slider EnemyHealthSlider;
        public Text EnemyName;
        public EffectIconUI[] EnemyEffectIcones;
    
        [Header("Inventory")]
        public InventoryUI InventoryWindow;
        public Button OpenInventoryButton;
        public AudioClip OpenInventoryClip;
        public AudioClip CloseInventoryClip;
    
        [Header("Quest")]
        public GameObject QuestWindow;
        public Button OpenQuestButton;
        
        // migrated to questUI
        [Header("Objectives")]
        public Transform ObjectivePointer1;
        public Transform ObjectivePointer2;

        Sprite m_ClosedInventorySprite;
        Sprite m_OpenInventorySprite;

        Sprite m_ClosedQuestSprite;
        Sprite m_OpenQuestSprite;

        private NavMeshPath path;
        private float elapsed = 0.0f;

        void Awake()
        {
            Instance = this;
        
            InventoryWindow.Init();
        }

        void Start()
        {
            m_ClosedInventorySprite = ((Image)OpenInventoryButton.targetGraphic).sprite;
            m_OpenInventorySprite = OpenInventoryButton.spriteState.pressedSprite;

            m_ClosedQuestSprite = ((Image)OpenQuestButton.targetGraphic).sprite;
            m_OpenQuestSprite = OpenQuestButton.spriteState.pressedSprite;

            for (int i = 0; i < TimedModifierIcones.Length; ++i)
            {
                TimedModifierIcones[i].gameObject.SetActive(false);
            }
        
            for (int i = 0; i < EnemyEffectIcones.Length; ++i)
            {
                EnemyEffectIcones[i].gameObject.SetActive(false);
            }
            
            path = new NavMeshPath();
            elapsed = 0.0f;
        }

        // Update is called once per frame
        void Update()
        {
            UpdatePlayerUI();
        }

        public void UpdateNavigationTarget(Transform target){
            ObjectivePointer1 = target;
        }

        void UpdatePlayerUI()
        {
            CharacterData data = PlayerCharacter.Data;       
            NavMeshHit hit,hit2;
        
            PlayerHealthSlider.value = PlayerCharacter.Data.Stats.CurrentHealth / (float) PlayerCharacter.Data.Stats.stats.health;
            MaxHealth.text = PlayerCharacter.Data.Stats.stats.health.ToString();
            CurrentHealth.text = PlayerCharacter.Data.Stats.CurrentHealth.ToString();
        
            if (PlayerCharacter.CurrentTarget != null)
            {
                UpdateEnemyUI(PlayerCharacter.CurrentTarget);
            }
            else
            {
                EnemyHealthSlider.gameObject.SetActive(false);
            }

            int maxTimedEffect = data.Stats.TimedModifierStack.Count;
            for (int i = 0; i < maxTimedEffect; ++i)
            {
                var effect = data.Stats.TimedModifierStack[i];

                TimedModifierIcones[i].BackgroundImage.sprite = effect.EffectSprite;
                TimedModifierIcones[i].gameObject.SetActive(true);
                TimedModifierIcones[i].TimeSlider.value = effect.Timer / effect.Duration;
            }

            for (int i = maxTimedEffect; i < TimedModifierIcones.Length; ++i)
            {
                TimedModifierIcones[i].gameObject.SetActive(false);
            }
        
                
            var stats = data.Stats.stats;

            StatsText.text = $"Str : {stats.strength} Def : {stats.defense} Agi : {stats.agility}";
            // Update the way to the goal every second     
            elapsed += Time.deltaTime;

            if (elapsed > 1.0f)
            {
                elapsed -= 1.0f;   
                for (int i = 0; i < 30; i++)
                {
                    if (NavMesh.SamplePosition(ObjectivePointer2.position, out hit2, 10.0f, NavMesh.AllAreas))
                    {
                        NavMesh.CalculatePath(hit2.position, ObjectivePointer1.position, NavMesh.AllAreas, path);
                    }
                }

                NavMesh.SamplePosition(ObjectivePointer1.position, out hit, 1.0f, NavMesh.AllAreas);
                
                if(path.corners.Length>0){
                    Vector3 diff = (path.corners[1] - ObjectivePointer2.position);
                    //We use aTan2 since it handles negative numbers and division by zero errors. 
                    float angle = Mathf.Atan2(diff.x, diff.z);
                    //Now we set our new rotation. 
                    ObjectivePointer2.rotation = Quaternion.Euler(90f, angle * Mathf.Rad2Deg, 0f);
                }
            }               
        }

        void UpdateEnemyUI(CharacterData enemy)
        {
            EnemyHealthSlider.gameObject.SetActive(true);
            EnemyHealthSlider.value = enemy.Stats.CurrentHealth / (float) enemy.Stats.stats.health;
            EnemyName.text = enemy.CharacterName;

            int top = enemy.Stats.ElementalEffects.Count;
        
            for (int i = 0; i < top; ++i)
            {
                var effect = enemy.Stats.ElementalEffects[i];
            
                EnemyEffectIcones[i].gameObject.SetActive(true);
                EnemyEffectIcones[i].TimeSlider.value = effect.CurrentTime / effect.Duration;
            }

            for (int i = top; i < EnemyEffectIcones.Length; ++i)
            {
                EnemyEffectIcones[i].gameObject.SetActive(false);
            }
        }

        public void ToggleInventory()
        {
            if (InventoryWindow.gameObject.activeSelf)
            {
                ((Image)OpenInventoryButton.targetGraphic).sprite = m_ClosedInventorySprite;
                InventoryWindow.gameObject.SetActive(false);
                SFXManager.PlaySound(SFXManager.Use.Sound2D, new SFXManager.PlayData(){ Clip = CloseInventoryClip});
            }
            else
            {
                ((Image)OpenInventoryButton.targetGraphic).sprite = m_OpenInventorySprite;
                InventoryWindow.gameObject.SetActive(true);
                InventoryWindow.Load(PlayerCharacter.Data);
                SFXManager.PlaySound(SFXManager.Use.Sound2D, new SFXManager.PlayData(){ Clip = OpenInventoryClip});
            }
        }

        public void ToggleQuest()
        {
            if (QuestWindow.gameObject.activeSelf)
            {
                ((Image)OpenQuestButton.targetGraphic).sprite = m_ClosedQuestSprite;
                QuestWindow.gameObject.SetActive(false);
                SFXManager.PlaySound(SFXManager.Use.Sound2D, new SFXManager.PlayData(){ Clip = CloseInventoryClip});
            }
            else
            {
                ((Image)OpenQuestButton.targetGraphic).sprite = m_OpenQuestSprite;
                QuestWindow.gameObject.SetActive(true);
                SFXManager.PlaySound(SFXManager.Use.Sound2D, new SFXManager.PlayData(){ Clip = OpenInventoryClip});
            }
        }
    }
}