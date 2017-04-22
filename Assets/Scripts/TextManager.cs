using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public static int lives = 1; // usunac statyczne
    //public string live;
    private Text liveText;

    void Start ()
    {
        liveText = FindObjectOfType<Text>();
        UpdateText();
    }

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
            liveText.text = "hello";
        UpdateText();
	}

    public void UpdateText()
    {
        //live = lives.ToString();
        liveText.text = "LIFES: " + lives.ToString();
    }
}
