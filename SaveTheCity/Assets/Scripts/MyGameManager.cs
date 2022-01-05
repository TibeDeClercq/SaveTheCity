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

    public Text PointsText;
    public float MaxPoints;
    public static float points;
    

    public enum GameStates //pauze toevoegen
    {
        Playing, Gameover, Victory
    }

    public static GameStates gameState;
    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }
        MyGameManager.gameState = GameStates.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameStates.Playing:
                mainCanvas.SetActive(true);
                victoryCanvas.SetActive(false);
                gameOverCanvas.SetActive(false);
                this.PointsText.text = MyGameManager.points.ToString();
                if(points >= MaxPoints)
                {
                    Destroy(Player.GetComponent<Shoot>());
                    //Player.GetComponent<FirstPersonController>().enabled = false;
                    //Player.GetComponent<CreateCamera>().enabled = true;
                    FirstPersonController.isWalking = false;
                    gameState = GameStates.Victory;
                }
                break;
            case GameStates.Gameover:
                mainCanvas.SetActive(false);
                victoryCanvas.SetActive(false);
                gameOverCanvas.SetActive(true);
                Destroy(Player.GetComponent<Shoot>());
                //Player.GetComponent<FirstPersonController>().enabled = false;
                //Player.GetComponent<CreateCamera>().enabled = true;
                FirstPersonController.isWalking = false;
                break;
            case GameStates.Victory:
                MyGameManager.points = 0;
                mainCanvas.SetActive(false);
                victoryCanvas.SetActive(true);
                gameOverCanvas.SetActive(false);
                break;
        }
    }
}
