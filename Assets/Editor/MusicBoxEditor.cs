using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MusicBox))]
public class MusicBoxEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MusicBox musicBox = target as MusicBox;

        if (GUILayout.Button("Move to next spawn point"))
        {
            musicBox.MoveToNext();
        }
    }

}
