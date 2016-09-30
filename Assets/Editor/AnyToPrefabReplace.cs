using UnityEngine;
using UnityEditor;
using System.Collections;

public class AnyToPrefabReplace : EditorWindow {

    public static Object replacement;

    [MenuItem("Tools/Replace with Prefab")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(AnyToPrefabReplace));
    }

    void OnGUI()
    {

        replacement = EditorGUILayout.ObjectField("Prefab:", replacement, typeof(GameObject), false);

        if (replacement != null)
        {
            if (GUILayout.Button("Replace Selection"))
            {
                Object[] objects = Selection.objects;
                Object[] selection = new Object[objects.Length];
                for (int i = 0; i < objects.Length; i++)
                {
                    GameObject obj = PrefabUtility.InstantiatePrefab(replacement) as GameObject;
                    Undo.RegisterCreatedObjectUndo(obj, "Created new prefab");
                    applyTransform(obj, (objects[i] as GameObject).transform);
                    Undo.DestroyObjectImmediate(objects[i]);
                    selection[i] = obj;
                }
                Selection.objects = selection;
            }
        }
    }

    private static void applyTransform(GameObject obj, Transform transform)
    {
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.transform.localScale = transform.localScale;
        obj.transform.parent = transform.parent;
        obj.transform.SetSiblingIndex(transform.GetSiblingIndex());
    }
}
