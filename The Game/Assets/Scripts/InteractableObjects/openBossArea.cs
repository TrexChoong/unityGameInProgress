using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;

public class openBossArea : InteractableObject
{
    public override bool IsInteractable
    {
        get
        {
            return true;
        }
    }

    public override void InteractWith(CharacterData target)
    {
       
    }
}
