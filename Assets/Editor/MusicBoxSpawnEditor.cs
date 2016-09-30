using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MusicBoxSpawn))]
public class MusicBoxSpawnEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MusicBoxSpawn spawnPoint = target as MusicBoxSpawn;
        MusicBoxSpawnList spawnList = spawnPoint.spawnList;

        if (!spawnList.Contains(spawnPoint.gameObject))
        {
            if (GUILayout.Button("Add to list"))
            {
                if (spawnList.Add(spawnPoint.gameObject))
                    apply(spawnList);
            }
        }
        else
        {
            if (GUILayout.Button("Remove from list"))
            {
                if (spawnList.Remove(spawnPoint.gameObject))
                    apply(spawnList);
            }
            GUILayout.Label("Order: " + spawnList.IndexOf(spawnPoint.gameObject));
            GUILayout.Space(10);
            if (GUILayout.Button("Select all"))
            {
                Selection.objects = spawnList.GetAll();

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
                if (spawnList.MoveUp(spawnPoint.gameObject))
                    apply(spawnList);
            }
            if (GUILayout.Button("Move Down"))
            {
                if (spawnList.MoveDown(spawnPoint.gameObject))
                    apply(spawnList);
            }
            GUILayout.Space(10);
            if (GUILayout.Button("Move Music Box here"))
            {
                GameManager.instance.musicBox.transform.position = spawnPoint.transform.position;
            }
        }
    }

    private void apply(MusicBoxSpawnList spawnList)
    {
        EditorUtility.SetDirty(spawnList);
        AssetDatabase.SaveAssets();
    }
}
