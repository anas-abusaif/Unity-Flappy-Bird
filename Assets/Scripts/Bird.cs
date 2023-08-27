using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    //define global variable
    Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private int score;
    public Text scoreText;
    public GameObject gameOver;
    public AudioSource jumpSound;
    public AudioSource coin;
    public AudioSource hit;

    // Start is called before the first frame update
    void Start()
    {
        // assign self Rigidbody2d component to global variable
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("AnimateBird", 0.15f, 0.15f);
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        //if the user presses Space button on keyboard
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            /* 
             * adds impulse force to the rigid body equal to
             * 0 on the X axis and 5 on the y axis
            */
            rb2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            jumpSound.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
        hit.Play();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString();
        coin.Play();


    }
    private void AnimateBird()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }


}
