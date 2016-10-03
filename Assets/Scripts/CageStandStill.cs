using UnityEngine;
using System.Collections;

public class CageStandStill : MonoBehaviour {
    public bool StandStill;
    private ActivateDome AD;

    void OnEnable()
    {
        AD = GameManager.instance.player.GetComponent<ActivateDome>();
        if (gameObject.name == "FirstAggroBox")
            return;
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
        {
            GameManager.instance.EnemyAggro();
            AD.spawnDomes = false;
            if (gameObject.name != "FirstAggroBox")
                AD.SprintTutorial();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == GameManager.instance.player && gameObject.name !="FirstAggroBox")
        {
            GameManager.instance.player.GetComponent<ActivateDome>().spawnDomes = true;
        }
    }
    void OnDisable()
    {
        GameManager.instance.EnemyDespawn();
    }
}
