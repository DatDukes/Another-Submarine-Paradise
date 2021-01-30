using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MovingEntity))]
public class MovingEntityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Entity myScript = (Entity)target;

        if (GUILayout.Button("Init"))
        {
            myScript.Init();
        }

        if (GUILayout.Button("Step")) 
        {
            myScript.Step();
        }
    }
}
