using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RessourceType
{
    Oxygen,
    Torpedo
}

public class RessourcesManager : MonoBehaviour
{
    [HideInInspector]
    public int oxygen 
    {
        get 
        {
            return _oxygen;
        }
        set 
        {
            if (value <= 0) GameManager.Instance.GameOver(false);
            _oxygen = value;
        }
    }
    private int _oxygen;
    [HideInInspector]
    public int torpedos;


    public TextMeshProUGUI OxygenFeedback;
    public TextMeshProUGUI TorpedoFeedback;

    // Start is called before the first frame update
    void Start()
    {
        oxygen = GameManager.Instance.gameSettings.startOxygen;

        OxygenFeedback.text = "Oxygen : " + oxygen;
        TorpedoFeedback.text = "Torpedos : " + torpedos;
    }

    public void LowerResource(RessourceType type , float value)
    {
        switch(type)
        {
            case RessourceType.Oxygen:
                oxygen -= (int)value;
                OxygenFeedback.text = "Oxygen : " + oxygen;
                break;
            case RessourceType.Torpedo:
                torpedos -= (int)value;
                TorpedoFeedback.text = "Torpedos : " + torpedos;
                break;
        }
    }
}
