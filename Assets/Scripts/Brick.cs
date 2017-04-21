using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hit_sprites;
    public AudioClip crack;
    public GameObject smoke;
    public float gravity_tweak;
    public float start_gravity;
    public Color powerup_color;
    public Brick[] trigger_bricks;

    public static int br_bricks;
    private Vector2 powerup_tweak;
    private int max_hits;
    private int timesHit;
    private LevelManager levelManager;
    private bool enabledTrigger = true;
    // Use this for initialization
    void Start () {
        start_gravity = FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().gravityScale;
        powerup_tweak = new Vector2(Random.Range(100f, 50f), Random.Range(100f, 50f));
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (this.tag == "Breakable")
            br_bricks++;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (this.tag == "Breakable")
            HandleHits();
        else if (this.tag == "BreakButNotMust")
            HandleHits();
        else if (this.tag == "Unbreakable" && this.name == "Trigger")
            Trigger();

        if (br_bricks <= 0)
            levelManager.LoadNextLevel();

        if (Time.deltaTime > 10)
            FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().gravityScale = start_gravity;
    }

    void HandleHits()
    {
        max_hits = hit_sprites.Length + 1;
        timesHit++;

        if (FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().gravityScale > start_gravity)
            FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().gravityScale -= 0.5f;
        else if (FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().gravityScale < start_gravity)
            FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().gravityScale += 0.5f;

        if (timesHit >= max_hits)
        {
            print(TextManager.points);
            TextManager.points += 10;
            print(TextManager.points);
            GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
            ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;
            main.startColor = this.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
            if (this.tag == "Breakable")
                br_bricks--;
            else if (this.name == "Slow")
                SlowBlock();
            else if (this.name == "Fast")
                FastBlock();
            else if (this.name == "High_gravity")
                HighGravityBlock();
            else if (this.name == "Low_gravity")
                LowGravityBlock();
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int i = timesHit - 1;
        if (hit_sprites[i])
            this.GetComponent<SpriteRenderer>().sprite = hit_sprites[i];
        else
            Debug.LogError("Missing sprite");
    }
    void SlowBlock()
    {
        FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().velocity += -powerup_tweak;
    }
    void FastBlock()
    {
        FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().velocity += powerup_tweak;
    }
    void HighGravityBlock()
    {
        FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().gravityScale += gravity_tweak;
        FindObjectOfType<Ball>().GetComponent<SpriteRenderer>().color = powerup_color;
    }
    void LowGravityBlock()
    {
        FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().gravityScale -= gravity_tweak;
    }
    void Trigger()
    {
        int i = trigger_bricks.Length - 1;
        print(i);
        if (enabledTrigger)
        {
            while (i >= 0)
            {
                trigger_bricks[i].GetComponent<SpriteRenderer>().enabled = false;
                trigger_bricks[i].GetComponent<BoxCollider2D>().enabled = false;
                i--;
            }
            enabledTrigger = false;
        }
        else
        {
            while (i >= 0)
            {
                trigger_bricks[i].GetComponent<SpriteRenderer>().enabled = true;
                trigger_bricks[i].GetComponent<BoxCollider2D>().enabled = true;
                i--;
            }
            enabledTrigger = true;
        }
    }
}
