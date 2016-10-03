using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MusicBoxSpawn))]
public class MusicBoxSpawnEditor : Editor {

    private static MusicBoxSpawnList _spawnList;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MusicBoxSpawn spawnPoint = target as MusicBoxSpawn;
        MusicBoxSpawnList spawnList = spawnPoint.spawnList;
        GameObject gameObject = target as GameObject;

        if (!spawnList || !spawnList.Contains(spawnPoint.gameObject))
        {
            if (GUILayout.Button("Add to list"))
            {
                if (addToList(spawnPoint, spawnList))
                    apply(spawnList);
            }
        }
        else
        {
            if (GUILayout.Button("Remove from list"))
            {
                if (spawnList.Remove(spawnPoint.gameObject))
                {
                    apply(spawnList);
                    DestroyImmediate(spawnPoint);
                    return;
                }
            }
            GUILayout.Label("Order: " + spawnList.IndexOf(spawnPoint.gameObject));
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

    private static bool addToList(MusicBoxSpawn spawnPoint, MusicBoxSpawnList spawnList)
    {
        spawnPoint.spawnList = spawnList ? spawnList : getSpawnList();
        return spawnList.Add(spawnPoint.gameObject);
    }

    private static MusicBoxSpawnList getSpawnList()
    {
        if (!_spawnList)
        {
            MusicBoxSpawn spawnPoint = FindObjectOfType(typeof(MusicBoxSpawn)) as MusicBoxSpawn;
            _spawnList = spawnPoint ? spawnPoint.spawnList : AssetDatabase.LoadAssetAtPath("Assets/Scripts/MusicBox/SpawnList.asset", typeof(MusicBoxSpawnList)) as MusicBoxSpawnList;
        }
        return _spawnList;
    }

    [MenuItem("Tools/Spawn List/Select All")]
    public static void SelectAll()
    {
        MusicBoxSpawnList spawnList = getSpawnList();
        Selection.objects = spawnList.GetAll();
        SceneView.lastActiveSceneView.FrameSelected();
    }

    [MenuItem("Tools/Spawn List/Add Selection")]
    public static void AddSelection()
    {
        Object[] objects = Selection.objects;
        MusicBoxSpawnList spawnList = getSpawnList();
        bool b = false;
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject obj = (objects[i] as GameObject);
            MusicBoxSpawn spawnPoint = obj.GetComponent<MusicBoxSpawn>();
            if (!spawnPoint)
            {
                obj.AddComponent<MusicBoxSpawn>();
                spawnPoint = obj.GetComponent<MusicBoxSpawn>();
                spawnPoint.spawnList = spawnList;
            }
            if (addToList(spawnPoint, spawnList))
                b = true;
        }
        if (b)
            apply(spawnList);
    }

    [MenuItem("Tools/Spawn List/Clear List")]
    public static void ClearList()
    {
        MusicBoxSpawn[] spawnPoints = GameObject.FindObjectsOfType<MusicBoxSpawn>();
        for (int i = 0; i < spawnPoints.Length; i++)
            DestroyImmediate(spawnPoints[i]);

        MusicBoxSpawnList spawnList = getSpawnList();
        spawnList.Clear();
        apply(spawnList);
    }

    private static void apply(MusicBoxSpawnList spawnList)
    {
        EditorUtility.SetDirty(spawnList);
        AssetDatabase.SaveAssets();
    }
}
