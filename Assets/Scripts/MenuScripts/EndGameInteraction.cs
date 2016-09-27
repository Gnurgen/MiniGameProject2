using UnityEngine;
using System.Collections;

public class EndGameInteraction : MonoBehaviour {

    public void ToMenu()
    {
        GameManager.instance.LeaveGame();
    }

    public void Respawn()
    {
        GameManager.instance.StartGame();
    }

}
