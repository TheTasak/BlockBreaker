using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose_Collider : MonoBehaviour {
    private Ball ball;
    private LevelManager levelManager;
    private TextManager textManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        textManager = FindObjectOfType<TextManager>();
        ball = FindObjectOfType<Ball>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (TextManager.lives > 0)
        {
            TextManager.lives--;
            textManager.UpdateText();
            ball.started = false;
            print(ball.transform.position);
            ball.transform.position = new Vector3(27.0f, 80.0f, ball.transform.position.y);
            print(ball.transform.position);
        }
        else
            levelManager.LoadLevel("Lose");

    }
}
