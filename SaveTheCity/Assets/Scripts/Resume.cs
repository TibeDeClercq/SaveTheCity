using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Utility;
using static MyGameManager;

public class Resume : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame

    public void LoadScene()
    {
        Player.GetComponent<CharacterController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player.GetComponent<FirstPersonController>().enabled = true;
        MyGameManager.gameState = GameStates.Playing;
        Timer.IsActive = true;
        NewWaypointProgressTracker.isDriving = true;
        FirstPersonController.isWalking = true;
        Player.GetComponent<Shoot>().enabled = true;
    }
}
