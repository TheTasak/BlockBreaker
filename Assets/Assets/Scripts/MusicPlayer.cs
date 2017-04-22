using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("duplicate");
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
