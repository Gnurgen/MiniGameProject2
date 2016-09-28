using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MusicBoxSpawn))]
public class MusicBoxSpawnEditor : Editor {

    public string prevOrder;
    public string order;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MusicBoxSpawn spawnPoint = target as MusicBoxSpawn;
        MusicBoxSpawnList spawnList = spawnPoint.spawnList;

        if (!spawnList.Contains(spawnPoint.gameObject))
        {
            if (GUILayout.Button("Add to list"))
            {
                spawnList.Add(spawnPoint.gameObject);
            }
        }
        else
        {
            if (GUILayout.Button("Remove from list"))
            {
                spawnList.Remove(spawnPoint.gameObject);
            }
            GUILayout.Label("Order: " + spawnList.IndexOf(spawnPoint.gameObject));
            GUILayout.Space(10);
            if (GUILayout.Button("Select all"))
            {
                spawnList.SelectAll();
            }
            GUILayout.Space(10);
            if (GUILayout.Button("Next"))
            {
                GameObject[] objects = { spawnList.Next(spawnPoint.gameObject) };
                Selection.objects = objects;
            }
            if (GUILayout.Button("Previous"))
            {
                GameObject[] objects = { spawnList.Prev(spawnPoint.gameObject) };
                Selection.objects = objects;
            }
            GUILayout.Space(10);
            if (GUILayout.Button("Move Up"))
            {
                spawnList.MoveUp(spawnPoint.gameObject);
            }
            if (GUILayout.Button("Move Down"))
            {
                spawnList.MoveDown(spawnPoint.gameObject);
            }
        }
    }

}
