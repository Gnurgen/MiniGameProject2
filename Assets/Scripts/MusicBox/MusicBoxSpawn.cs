﻿using UnityEngine;
using System.Collections;

public class MusicBoxSpawn : MonoBehaviour {

    private static MusicBoxSpawn current;

    [HideInInspector]
    public MusicBoxSpawnList spawnList;

    void Start () {
        if (current == null)
        {
            current = spawnList.First().GetComponent<MusicBoxSpawn>();
            GameManager.instance.musicBox.transform.position = current.transform.position;
        }
    }

    void Update () {

    }

    public static void SetCurrent(MusicBoxSpawn spawnPoint)
    {
        current = spawnPoint;
    }

    public static int GetCount() {
        return current.spawnList.Count();
    }

    public static MusicBoxSpawn GetNext()
    {
        GameObject spawnPoint = current.spawnList.Next(current.gameObject);
        if (spawnPoint == null)
            spawnPoint = current.spawnList.First();
        return spawnPoint.GetComponent<MusicBoxSpawn>();
    }
}
