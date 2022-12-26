using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[] character;
    public float textSpeed;
    [SerializeField]
    private Behaviour CharacterController;
    [SerializeField]
    private GameObject cam1,cam2,disablecam,player,npc,button;
    private int index;
    private bool interactPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && index < lines.Length - 1 && interactPressed)
        {
            if(textComponent.text == character[index] + ":\n" + lines[index])
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

    public void StartDialogue()
    {
        interactPressed = true;
        player.transform.LookAt(npc.transform);
        npc.transform.LookAt(player.transform);
        CharacterController.enabled = false;
        disablecam.SetActive(false);
        Color col = GetComponent<RawImage>().color;
        col.a = 1;
        GetComponent<RawImage>().color = col;
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        if(character[index] == "MOOSE")
        {
           cam1.SetActive(false);
           cam2.SetActive(true);
        }
        else if (character[index] == "NPC")
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
        if(index == lines.Length - 2)
        {
            button.SetActive(true);
        }
        if (index < lines.Length - 1)
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
            gameObject.SetActive(false);
        }
    }

    public void ButtonPress()
    {
        if (textComponent.text == character[index] + ":\n" + lines[index])
        {
            interactPressed = false;
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = character[index] + ":\n" + lines[index];
        }
    }
}
