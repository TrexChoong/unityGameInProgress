using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CreatorKitCodeInternal;
using UnityEngine.SceneManagement;

namespace CreatorKitCodeInternal
{
    public class Dialogue : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public TMP_Text buttonText;
        public string[] lines;
        public string[] character;
        public QuestUI instanceUI;
        public float textSpeed;
        [SerializeField]
        private Behaviour CharacterController;
        [SerializeField]
        private GameObject cam1, cam2, disablecam, player, npc, button;

        private Animator playerAnim;
        private Vector3 lockRotation;
        private int index;
        private Color col;
        private bool interactPressed = false;
        private string mainCha = "MOOSE";
        private string NPC = "ILAMA";
        // Start is called before the first frame update
        void Start()
        {
            playerAnim = player.GetComponentInChildren<Animator>();
            col = GetComponent<RawImage>().color;
            textComponent.text = string.Empty;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && lines[index + 1] != "" && interactPressed)
            {
                if (textComponent.text == character[index] + ":\n" + lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = character[index] + ":\n" + lines[index];
                }
            }
        }

        public void StartDialogue(int dialogueCount)
        {
            playerAnim.SetFloat("Speed",0);
            interactPressed = true;
            player.transform.LookAt(npc.transform);
            npc.transform.LookAt(new Vector3(player.transform.position.x, npc.transform.position.y, player.transform.position.z));
            CharacterController.enabled = false;
            disablecam.SetActive(false);
            col.a = 1;
            GetComponent<RawImage>().color = col;
            index = dialogueCount * 10;
            StartCoroutine(TypeLine());
        }
        IEnumerator TypeLine()
        {
            if (character[index] == mainCha)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
            else if (character[index] == NPC)
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
            textComponent.text += character[index] + ":\n";
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void NextLine()
        {
            if (lines[index+2]=="")
            {
                button.SetActive(true);
                if(index > 20)
                {
                    buttonText.text = "End Game";
                }
                else
                {
                    buttonText.text = "Accept";
                }
            }
            if (lines[index+1] != "")
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());

            }
            else
            {
                button.SetActive(false);
                CharacterController.enabled = true;
                disablecam.SetActive(true);
                cam1.SetActive(false);
                cam2.SetActive(false);
                col.a = 0;
                GetComponent<RawImage>().color = col;
                textComponent.text = string.Empty;
                instanceUI.ProgressQuest();
                if (index > 20)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                //gameObject.SetActive(false);
            }
        }

        public void ButtonPress()
        {
            if (textComponent.text == character[index] + ":\n" + lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = character[index] + ":\n" + lines[index];
                interactPressed = false;

            }
        }
    }
}
