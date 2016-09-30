using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(fileName = "SpawnList", menuName = "MusicBox/SpawnList", order = 9999)]
public class MusicBoxSpawnList : ScriptableObject {

    [SerializeField]
    public List<string> list = new List<string>();

    public bool Add(GameObject obj)
    {
        if (!list.Contains(obj.name))
        {
            list.Add(obj.name);
            return true;
        }
        return false;
    }

    public bool Remove(GameObject obj)
    {
        if (list.Contains(obj.name))
        {
            list.Remove(obj.name);
            return true;
        }
        return false;
    }

    public bool Contains(GameObject obj)
    {
        return list.Contains(obj.name);
    }

    public int IndexOf(GameObject obj)
    {
        return list.IndexOf(obj.name);
    }

    public bool MoveUp(GameObject obj)
    {
        int index = list.IndexOf(obj.name);
        if (index + 1 < list.Count)
        {
            string temp = list[index + 1];
            list[index + 1] = list[index];
            list[index] = temp;
            return true;
        }
        return false;
    }

    public bool MoveDown(GameObject obj)
    {
        int index = list.IndexOf(obj.name);
        if (index - 1 >= 0)
        {
            string temp = list[index - 1];
            list[index - 1] = list[index];
            list[index] = temp;
            return true;
        }
        return false;
    }

    public GameObject First() {
        if (list.Count > 0)
            return GameObject.Find(list[0]);
        return null;
    }

    public GameObject Next(GameObject obj)
    {
        int index = list.IndexOf(obj.name);
        return GameObject.Find(list[index + 1 < list.Count ? index+1 : 0]);
    }

    public GameObject Prev(GameObject obj)
    {
        int index = list.IndexOf(obj.name);
        return GameObject.Find(list[index - 1 >= 0 ? index-1 : list.Count-1]);
    }

    public GameObject[] GetAll()
    {
        GameObject[] objects = new GameObject[list.Count];
        for (int i = 0; i < list.Count; i++)
            objects[i] = GameObject.Find(list[i]);
        return objects;
    }

    public bool RemoveInvalidEntries()
    {
        bool b = false;
        for (int i = 0; i < list.Count;)
            if (!GameObject.Find(list[i]))
            {
                Debug.LogError("GameObject \"" + list[i] + "\" in Music Box spawn list not found. Removing invalid entry.");
                list.RemoveAt(i);
                b = true;
            }
            else
                i++;
        return b;
    }
}