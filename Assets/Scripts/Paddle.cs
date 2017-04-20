using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	// Use this for initialization

    public bool autoPlay;
    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	void Update () {
        if (!autoPlay)
            MoveWithMouse();
        else
            AutoPlay();

        if (Input.GetKeyDown(KeyCode.A) && autoPlay == false)
            autoPlay = true;
        else if (Input.GetKeyDown(KeyCode.A) && autoPlay)
            autoPlay = false;


	}

    void MoveWithMouse()
    {
        Vector3 posision = new Vector3(-60f, this.transform.position.y, 0f);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 400 - 200;
        posision.x = Mathf.Clamp(mousePosInBlocks, -200.0f, 200f);
        this.transform.position = posision;
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(ball.transform.position.x, this.transform.position.y, 0f);
        this.transform.position = paddlePos;
    }
}
