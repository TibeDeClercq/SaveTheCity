using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevel : MonoBehaviour
{
    public string _LevelToLoad;
    public void LoadLevel()
    {
        SceneManager.LoadScene(_LevelToLoad);
    }
}
