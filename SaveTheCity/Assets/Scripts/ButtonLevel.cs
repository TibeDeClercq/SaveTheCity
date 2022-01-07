using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevel : MonoBehaviour
{
    public string _LevelToLoad;
    public void LoadLevel()
    {
        MyGameManager.points = 0;
        SceneManager.LoadScene(_LevelToLoad);
    }
}
