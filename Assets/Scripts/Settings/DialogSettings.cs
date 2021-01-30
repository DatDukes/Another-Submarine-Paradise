using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogSettings", order = 1)]
public class DialogSettings : ScriptableObject
{
    public DialogData[] EnemyEncounterDialogs;

    public DialogData[] StashEncounterDialogs;

    public DialogData[] PeacefullEncounterDialogs;
}
