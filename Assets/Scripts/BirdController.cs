using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public Sprite deadBird;
    public float horSpeed = 5f;
    public float verSpeed = 3f;
    public bool controlEnabled = true;
    private GameManager gameManager;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
            return;
        else
            anim.SetTrigger("gameStarted");

        if (controlEnabled)
        {
            float v = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(horSpeed, v * verSpeed);
        }        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        rb.gravityScale = 10;
        horSpeed = 0;
        controlEnabled = false;
        anim.SetTrigger("dead");
        GetComponent<BirdController>().enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = deadBird;
    }
}
