using UnityEngine;
using System.Collections;

public class FenceTrigger : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == GameManager.instance.player) {
            GameObject.Find("FirstAggroBox").SetActive(false);
            GameManager.instance.enemy.GetComponent<NavMeshController>().enabled = false;
            GameManager.instance.enemy.GetComponent<OneShotAnis>().enabled = true;
            GameManager.instance.enemy.GetComponent<OneShotAnis>().playOneShot();
            gameObject.SetActive(false);
        }
    }
}
