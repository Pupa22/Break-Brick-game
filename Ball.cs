using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform Explosion;
    public Transform powerup;

    public GameManager gm;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        if (!inPlay){
            transform.position = paddle.position;
        }
        if (Input.GetButtonDown("Jump") && !inPlay){
            inPlay = true; 
            rb.AddForce(Vector2.up * 500);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }  
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            Brick brickScript = other.gameObject.GetComponent<Brick>();

            if (brickScript.hitsToBreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {

                int randchance = Random.Range(1, 101); #สุ่มการเกิดpowerup
                if (randchance < 20)
                {
                    Instantiate(powerup, other.transform.position, other.transform.rotation);
                }


                Transform newExplosion = Instantiate(Explosion, other.transform.position, other.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                gm.UpdateScore(brickScript.points);
                gm.UpdateNumberofBrick();

                Destroy(other.gameObject);
            }
        }
    }

}
