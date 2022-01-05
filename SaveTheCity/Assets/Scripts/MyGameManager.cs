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
    public GameObject victoryCanvas;
    public float endTimer;
    public Text timer;
    public Text pointsTimer;
    public float cars;
    private float count;
    private float points;
    

    public enum GameStates //pauze toevoegen
    {
        Playing, Gameover, Victory
    }

    public static GameStates gameState = GameStates.Playing;
    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }
        mainCanvas.SetActive(true);
        victoryCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        points = float.Parse(pointsTimer.text);
        count = float.Parse(timer.text);
        switch (gameState)
        {
            case GameStates.Playing:
                if (count >= endTimer) //aanpassen timer
                {
                    Destroy(Player.GetComponent<Shoot>());
                    //Player.GetComponent<FirstPersonController>().enabled = false;
                    //Player.GetComponent<CreateCamera>().enabled = true;
                    FirstPersonController.isWalking = false;
                    gameState = GameStates.Gameover;
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                }
                if(points >= cars)
                {
                    Destroy(Player.GetComponent<Shoot>());
                    //Player.GetComponent<FirstPersonController>().enabled = false;
                    //Player.GetComponent<CreateCamera>().enabled = true;
                    FirstPersonController.isWalking = false;
                    gameState = GameStates.Victory;
                    mainCanvas.SetActive(false);
                    victoryCanvas.SetActive(true);
                }
                break;
        }
    }
}
