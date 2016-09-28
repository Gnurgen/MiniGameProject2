using UnityEngine;
using System.Collections;

public class CageStandStill : MonoBehaviour {
    public bool StandStill;

    void OnEnable()
    {
        if (!(gameObject.tag == "SortedDomeSpawn"))
        {
            if (GameObject.FindGameObjectWithTag("Cage") != null)
                GameObject.FindGameObjectWithTag("Cage").SetActive(false);
            GameManager.instance.EnemySpawn();
            GameManager.instance.enemy.GetComponent<NavMeshController>().setCage(transform);
            gameObject.tag = "Cage";
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == GameManager.instance.player)
            GameManager.instance.EnemyAggro();
    }
    void OnDisable()
    {
        GameManager.instance.EnemyDespawn();
        gameObject.tag = "Dome";
    }
}
