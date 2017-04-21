using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public static int lives = 0; // usunac statyczne
    public static int points = 0;// usunac statyczne
    public Text liveText;
    public Text pointText;

    void Start ()
    {
        lives = 0;
        points = 0;
        UpdateText();
        liveText.text = lives.ToString();
        pointText.text = points.ToString();
    }

	
	// Update is called once per frame
	void Update () {
        UpdateText();
	}

    public void UpdateText()
    {
        print("dskafjlaskfhello world");
        liveText.text = lives.ToString();
        pointText.text = points.ToString();
        print(lives);
        print(points);
    }
}
