using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCreditScene : MonoBehaviour
{
    public void SkipScene()
    {
        SceneManager.LoadScene(0);
    }
}
