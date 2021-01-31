using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    public void AddLog(string text) 
    {
        text += "\n" + dialogText.text;
        dialogText.text = text;
    }
}
