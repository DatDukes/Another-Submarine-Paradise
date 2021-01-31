using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public Entity player;
    public Image ui;
    public Transform[] position;
    public Sprite[] indices;
    public WinCondition CurrentWinCondition;

    private WinCondition[] windcondition;

    public void Start()
    {
        windcondition = new WinCondition[position.Length];

        for(int i = 0; i< windcondition.Length; i++) 
        {
            windcondition[i] = new WinCondition(indices[i], position[i].position);
        }

        CurrentWinCondition = windcondition[Random.Range(0, windcondition.Length)];
        ui.sprite = CurrentWinCondition.clue;
    }

    public void CheckWinCondition() 
    {
        if(player.position == CurrentWinCondition.position) 
        {
            Debug.Log("You Win");
        }
        else 
        {
            Debug.Log("Missed");
        }
    }
}
