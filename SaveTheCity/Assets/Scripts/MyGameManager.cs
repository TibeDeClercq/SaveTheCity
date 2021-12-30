using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MyGameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public float endTimer;
    public Text timer;
    private float count;

    public enum GameStates
    {
        Playing, Gameover
    }

    public GameStates gameState = GameStates.Playing;
    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }
        mainCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        count = float.Parse(timer.text);
        switch (gameState)
        {
            case GameStates.Playing:
                if (count >= endTimer)
                {
                    Destroy(Player.GetComponent<Shoot>());
                    //Player.GetComponent<FirstPersonController>().enabled = false;
                    //Player.GetComponent<CreateCamera>().enabled = true;
                    FirstPersonController.isWalking = false;
                    gameState = GameStates.Gameover;
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                }
                break;
        }
    }
}
