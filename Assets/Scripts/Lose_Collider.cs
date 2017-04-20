using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose_Collider : MonoBehaviour {

    private LevelManager levelManager;
	void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager.LoadLevel("Lose");
    }
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
}
