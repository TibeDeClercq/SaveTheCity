using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Utility;

public class MyGameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public GameObject victoryCanvas;
    public GameObject pauseCanvas;

    public Text PointsText;
    public float MaxPoints;
    public static float points;
    

    public enum GameStates //pauze toevoegen
    {
        Playing, Gameover, Victory, Pause
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
                pauseCanvas.SetActive(false);
                this.PointsText.text = MyGameManager.points.ToString() + "/" + this.MaxPoints.ToString();
                if (Input.GetKeyDown(KeyCode.Escape))
                    gameState = GameStates.Pause;
                if (points >= MaxPoints)
                {                    
                    gameState = GameStates.Victory;
                }
                break;
            case GameStates.Gameover:
                Debug.Log("Changed to gameover state");
                mainCanvas.SetActive(false);
                victoryCanvas.SetActive(false);
                gameOverCanvas.SetActive(true);
                Destroy(Player.GetComponent<Shoot>());
                Player.GetComponent<CharacterController>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Player.GetComponent<FirstPersonController>().enabled = false;
                //Player.GetComponent<CreateCamera>().enabled = true;
                FirstPersonController.isWalking = false;
                break;
            case GameStates.Victory:
                Debug.Log("Changed to victory state");
                Destroy(Player.GetComponent<Shoot>());
                Player.GetComponent<CharacterController>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Player.GetComponent<FirstPersonController>().enabled = false;
                FirstPersonController.isWalking = false;
                MyGameManager.points = 0;
                mainCanvas.SetActive(false);
                victoryCanvas.SetActive(true);
                gameOverCanvas.SetActive(false);
                break;
            case GameStates.Pause:
                Player.GetComponent<CharacterController>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Player.GetComponent<FirstPersonController>().enabled = false;
                FirstPersonController.isWalking = false;
                NewWaypointProgressTracker.isDriving = false;
                Timer.IsActive = false;
                Player.GetComponent<Shoot>().enabled = false;
                pauseCanvas.SetActive(true);
                break;
        }
    }
}
