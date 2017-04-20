using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("Level load" + name);
        Brick.br_bricks = 0;
        Application.LoadLevel(name);
    }
    public void QuitGame()
    {
        Debug.Log("Qutting game");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        Brick.br_bricks = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
