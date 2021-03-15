using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text scoreText;
    public Text winText;
    public Text livesText;
    public Text loseText;

    private int scoreValue;
    private int livesValue;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        scoreValue = 0;
        winText.text = "";
        loseText.text = "";
        livesValue = 3;
        livesText.text = "Lives: " + livesValue.ToString();
        scoreText.text = "Score: " + scoreValue.ToString ();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

     if (Input.GetKeyDown(KeyCode.W))

        {

          anim.SetInteger("State", 3);

         }

     if (Input.GetKeyUp(KeyCode.W))

        {

          anim.SetInteger("State", 0);

         }

     if (Input.GetKeyDown(KeyCode.D))

        {

          anim.SetInteger("State", 2);

         }

     if (Input.GetKeyUp(KeyCode.D))

        {

          anim.SetInteger("State", 0);

         }

    if (Input.GetKeyDown(KeyCode.A))

        {

          anim.SetInteger("State", 2);

         }

     if (Input.GetKeyUp(KeyCode.A))

        {

          anim.SetInteger("State", 0);

         }


    }


    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            scoreText.text = "Score: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
             if (scoreValue >= 8)
             {
                 winText.text = "You Win! Game Created by Alysia Ramirez";
             }
             if (scoreValue == 4) 
            {
             transform.position = new Vector3(40.0f, 0.0f, 0.0f); 
             livesValue = 3;
             livesText.text = "Lives: " + livesValue.ToString();
            }
        }

        if (collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
            livesText.text = "Lives: " + livesValue.ToString();
            Destroy(collision.collider.gameObject);
            if (livesValue <= 0)
             {
                 loseText.text = "You Lose!";
                 Destroy(gameObject);
             }
        }

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }

}

