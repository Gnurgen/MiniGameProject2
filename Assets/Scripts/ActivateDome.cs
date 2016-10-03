using UnityEngine;
using System.Collections;

public class ActivateDome : MonoBehaviour {

    private GameObject[] domeTrans;
    private ThumbSprintController sprintCanvas;
    private Vector3[] domePos;
    private int activeDome, index;
    private float dist;
    [HideInInspector]
    public bool spawnDomes = false;

    private bool _hasSprinted = false;

	void Start () {
        GameManager.instance.OnPlayerSprint += setSprinted;
        domeTrans = GameObject.FindGameObjectsWithTag("SortedDomeSpawn");
        sprintCanvas = GameObject.Find("ThumbPrint").GetComponent<ThumbSprintController>();
        domePos = new Vector3[domeTrans.Length];
        for(int x = 0; x<domeTrans.Length; ++x)
        {
            domePos[x] = domeTrans[x].transform.position;
            domeTrans[x].tag = "Dome";
            domeTrans[x].SetActive(false);
        }
	}
	
	void Update () {
        if (spawnDomes)
        {
            if (index > domePos.Length - 1)
            {
                domeTrans[activeDome].SetActive(true);
                index = 0;
                dist = Vector3.Distance(transform.position, domePos[index]);
                activeDome = index;
                ++index;
            }
            if (dist > Vector3.Distance(transform.position, domePos[index]))
            {
                activeDome = index;
                dist = Vector3.Distance(transform.position, domePos[index]);
            }
            index++;
        }
	}
    
    public void SprintTutorial()
    {
        if (!_hasSprinted)
            sprintCanvas.ShowThumbs();
    }
    private void setSprinted()
    {
        _hasSprinted = true;
    }
}
