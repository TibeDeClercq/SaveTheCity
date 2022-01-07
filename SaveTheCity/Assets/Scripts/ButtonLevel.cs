using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Utility;

public class ButtonLevel : MonoBehaviour
{
    public string _LevelToLoad;
    public void LoadLevel()
    {
        NewWaypointProgressTracker.isDriving = true;
        Timer.IsActive = true;
        MyGameManager.points = 0;
        SceneManager.LoadScene(_LevelToLoad);
    }
}
