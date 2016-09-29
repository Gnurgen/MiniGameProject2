using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MusicBox))]
public class MusicBoxEditor : Editor
{

    private bool prevRewind = false;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MusicBox musicBox = target as MusicBox;

        if (Application.isPlaying)
        {
            if (GUILayout.RepeatButton("Rewind"))
            {
                if (!prevRewind)
                    GameManager.instance.MusicBoxRewindStart();
                prevRewind = true;
            }
            else
            {
                if (prevRewind)
                    GameManager.instance.MusicBoxRewindStop();
                prevRewind = false;
            }
        }
    }

}
