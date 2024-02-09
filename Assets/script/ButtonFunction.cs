using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    public void ExitGame() 
    { 
        GameManager.instance.ExitGame();
    } 
    public void LoadScene(string name) 
    { 
        GameManager.instance.LoadScene(name);
    }
}
