using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Vector3 paddleToBallVec;
    private bool started = false;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVec = this.transform.position - paddle.transform.position;
        print(paddleToBallVec);
	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            this.transform.position = paddle.transform.position + paddleToBallVec;
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(150f, 300f);
                started = true;
            }
            else if (paddle.autoPlay)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(150f, 300f);
                started = true;
            }
        }
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        GetComponent<Rigidbody2D>().velocity += tweak;
        if (started)
            GetComponent<AudioSource>().Play();
    }
}
