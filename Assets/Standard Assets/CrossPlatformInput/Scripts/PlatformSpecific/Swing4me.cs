using UnityEngine;
using System.Collections;

public class Swing4me : MonoBehaviour {

    private bool swinging = false;
    void OnTriggerStay (Collider col)
    {
        if (Input.touchCount == 5)
        {
            col.gameObject.transform.SetParent(transform.parent.GetChild(0).GetChild(0).GetChild(0));
            col.gameObject.transform.position = transform.parent.GetChild(0).GetChild(0).GetChild(0).position;
            swinging = true;
            transform.parent.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = false;
        }
        if (swinging && Input.touchCount >= 6)
        {
            col.transform.SetParent(null);
            col.transform.position = transform.position;
            swinging = false;
            col.transform.rotation = Quaternion.identity;
            transform.parent.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = true;

        }
    }
    
}

