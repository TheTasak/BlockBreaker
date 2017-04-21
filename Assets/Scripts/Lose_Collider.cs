using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose_Collider : MonoBehaviour {
    public Ball ball;
    private LevelManager levelManager;
    private TextManager textManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        textManager = FindObjectOfType<TextManager>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (TextManager.lives > 0)
        {
            TextManager.lives--;
            textManager.UpdateText();
            ball.started = false;
            ball.transform.position = ball.ballStartPos;
        }
        else
            levelManager.LoadLevel("Lose");

    }
}
