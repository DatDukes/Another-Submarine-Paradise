using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Entity))]
public class EntityEditor : Editor
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